using CefSharp;
using CefSharp.WinForms;
using SessionIsoBrowser.Data;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class BrowserWindow : Form
    {
        public string sUUID;
        GMApi.GM_API_Handler GM;
        ChromiumWebBrowser webBro;
        Data.SessionInfo session;
        List<UserScript> scripts = new List<UserScript>();

        public BrowserWindow(Data.SessionInfo session, bool keepDebugWindow = false)
        {
            GM = new GMApi.GM_API_Handler(session.UUID, this);
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Text = session.SessionName + " - " + Properties.Settings.Default.Title;
            webBro = new ChromiumWebBrowser();

            logger.AppendText("脚本加载器任务：准备脚本数据\n\n正在预加载脚本...\n");

            webBro.RequestContext = Data.CM.GetContext(session.UUID).context;
            browserLayoutPanel.Controls.Add(webBro);
            webBro.Dock = DockStyle.Fill;
            webBro.LifeSpanHandler = new Common.Control.CefSharpOpenPageSelf();
            webBro.AddressChanged += onAddrChange;
            webBro.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            webBro.JavascriptObjectRepository.Register("GM", GM, false);

            this.session = session;
            sUUID = session.UUID;
            Task t = Task.Run(async () =>
            {
                List<string> Uscripts = Data.VDB.GetSessionRelatedScripts(session.UUID);
                scripts.Clear();
                int cnt = 0;
                foreach (string urlstr in Uscripts)
                {
                    if (urlstr.Length < 1) continue;
                    try
                    {
                        logger.AppendText("加载:" + urlstr + "\n");
                        if (this.IsDisposed) return;
                        UserScript script = null;
                        Uri url = new Uri(urlstr);
                        if (url.Scheme == "localscript")
                        {
                            script = new LocalUserScriptHandler(session).GetLocalUserScript(url.Host);
                        }
                        else if (url.Scheme == "globalscript")
                        {
                            script = LocalUserScriptHandler.GetUserScript(url.Host);
                        }
                        else
                        {
                            var code = Data.ScriptFetchEngine.GetScriptContent(urlstr, session);
                            script = new UserScript(code);
                        }
                        if (script == null ||
                        script.conf.Name == null ||
                        script.conf.Name == "")
                            continue;
                        logger.AppendText("正在准备预定义资源...\n");
                        foreach (KeyValuePair<string, string> kvp in script.conf.Resources)
                        {
                            if (this.IsDisposed) return;
                            logger.AppendText("[" + kvp.Key + "]\t" + kvp.Value + " \t");
                            try
                            {
                                GM.storage.preLoadResources.Add(kvp.Key, new GMApi.StorageSystem.Resource()
                                {
                                    content = ScriptFetchEngine.GetScriptContent(kvp.Value),
                                    url = kvp.Value

                                });
                                logger.AppendText("Done. Len=" +
                                    GM.storage.preLoadResources[kvp.Key].content.Length
                                    + "\n");
                            }
                            catch
                            {
                                GM.storage.preLoadResources.Add(kvp.Key, new GMApi.StorageSystem.Resource()
                                {
                                    content = "",
                                    url = kvp.Value
                                });
                                logger.AppendText("Fail.\n");
                            }
                        }
                        scripts.Add(script);
                        logger.AppendText("当前脚本完成。\n\n");
                        cnt++;
                        this.Text = session.SessionName + "(Script*" + cnt + ") - " + Properties.Settings.Default.Title;
                    }
                    catch (Exception err)
                    {
                        logger.AppendText("脚本加载出现问题：" + err.Message + "\n调用栈:\n");
                        logger.AppendText(err.StackTrace + "\n");
                    }
                }
                if (this.IsDisposed) return;
                logger.AppendText("预加载完成，开始载入网页。\n");
                await Task.Delay(1000);
                if (this.IsDisposed) return;
                if (!keepDebugWindow) logger.Hide();
                webBro.FrameLoadEnd += onFrameLoadEnd;
                webBro.Load(session.Url);
            });
        }

        public void onFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            args.Frame.ExecuteJavaScriptAsync("GM_setValue = GM.setValue;" +
                "GM_getValue = GM.getValue;" +
                "GM_setClipboard = GM.setClipboard;" +
                "GM_xmlhttpRequest = GM.xmlhttpRequest;" +
                "GM_deleteValue = GM.deleteValue;" +
                "GM_listValues = GM.listValues;" +
                "GM_addValueChangeListener = GM.addValueChangeListener;" +
                "GM_removeValueChangeListener = GM.removeValueChangeListener;" +
                "GM_log = GM.log;" +
                "GM_getResourceText = GM.getResourceText;" +
                "GM_getResourceURL = GM.getResourceURL;" +
                "unsafeWindow = window;");
            args.Frame.ExecuteJavaScriptAsync(Properties.Settings.Default.EnvScript);
            foreach (UserScript script in scripts)
            {
                if (script.IsAvailableInPage(args.Url))
                    args.Frame.ExecuteJavaScriptAsync(script.JSCode);
            }
        }

        public void onAddrChange(object sender, AddressChangedEventArgs args)
        {
            if (Regex.IsMatch(args.Address, ".*.user\\.js"))
            {
                new InstallNewScript(session, args.Address).ShowDialog();
                args.Browser.GoBack();
            }
            else
                url.Text = args.Address;
        }

        private void BrowserWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(url.Text, ".*.user\\.js"))
            {
                this.session.Url = url.Text;
                Data.VDB.PutSessionInfo(this.session);
            }
            webBro.Load(url.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBro.ShowDevTools();
        }

        private void browserLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void url_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBro.Load(url.Text);
            }
        }
    }
}
