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
        public string UUID;
        ChromiumWebBrowser webBro;
        Data.SessionInfo session;
        List<UserScript> scripts = new List<UserScript>();

        public BrowserWindow(Data.SessionInfo session)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Text = session.SessionName + " - " + Properties.Settings.Default.Title;
            webBro = new ChromiumWebBrowser();
            webBro.RequestContext = Data.CM.GetContext(session.UUID).context;
            browserLayoutPanel.Controls.Add(webBro);
            webBro.Dock = DockStyle.Fill;
            webBro.LifeSpanHandler = new Common.Control.CefSharpOpenPageSelf();
            webBro.AddressChanged += onAddrChange;
            webBro.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            webBro.JavascriptObjectRepository.Register("GM", Data.CM.GetContext(session.UUID).GM, false);
            this.session = session;
            UUID = session.UUID;
            webBro.Load(session.Url);
            Task.Run(async () =>
            {
                List<string> Uscripts = Data.VDB.GetSessionRelatedExtentions(session.UUID);
                scripts.Clear();
                int cnt = 0;
                foreach (string urlstr in Uscripts)
                {
                    try
                    {
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
                        scripts.Add(script);
                        cnt++;
                        this.Text = session.SessionName + "(Script*" + cnt + ") - " + Properties.Settings.Default.Title;
                    }
                    catch { }
                }
                webBro.FrameLoadEnd += onFrameLoadEnd;
            });
        }

        public void onFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            args.Frame.ExecuteJavaScriptAsync("GM_setValue = GM.setValue;" +
                "GM_getValue = GM.getValue;" +
                "GM_setClipboard = GM.setClipboard;" +
                "GM_xmlhttpRequest = GM.xmlhttpRequest;" +
                "unsafeWindow = window;");
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
            if(e.KeyCode == Keys.Enter)
            {
                webBro.Load(url.Text);
            }
        }
    }
}
