using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using SessionIsoBrowser.GMApi;

namespace SessionIsoBrowser
{
    public partial class BrowserWindow : Form
    {
        public string UUID;
        ChromiumWebBrowser webBro;
        Data.SessionInfo session;
        List<string> scripts = new List<string>();
        bool scriptsLoaded = false;

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
                scriptsLoaded = false;
                int cnt = 0;
                foreach (string url in Uscripts)
                {
                    try
                    {
                        var code = Data.ScriptFetchEngine.GetScriptContent(url);
                        if (code.Length < 1) continue;
                        scripts.Add(code);
                        cnt++;
                        this.Text = session.SessionName + "(Script*" + cnt + ") - " + Properties.Settings.Default.Title;
                    }
                    catch { }
                }
                scriptsLoaded = true;
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
            foreach (string code in scripts)
            {
                args.Frame.ExecuteJavaScriptAsync(code);
            }
        }

        public void onAddrChange(object sender, AddressChangedEventArgs args)
        {
            url.Text = args.Address;
        }

        private void BrowserWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.session.Url = url.Text;
            Data.VDB.PutSessionInfo(this.session);
            webBro.Load(url.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBro.ShowDevTools();
        }

        private void browserLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
