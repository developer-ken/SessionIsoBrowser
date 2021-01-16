using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class SessionManager : Form
    {
        private List<BrowserWindow> openWindows = new List<BrowserWindow>();
        public SessionManager()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            settings.UserAgent = Data.VDB.UserAgent;
            settings.RemoteDebuggingPort = 8088;
            settings.Locale = "zh-CN";
            settings.IgnoreCertificateErrors = true;
            settings.LogSeverity = LogSeverity.Verbose;
            settings.CachePath = System.IO.Path.GetFullPath(Data.VDB.savepath);
            settings.PersistSessionCookies = true;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            CefSharpSettings.WcfEnabled = true;
            Cef.Initialize(settings);
            this.Text = Properties.Settings.Default.Title + " - 会话管理器";
            RefreshList();
        }

        public void RefreshList()
        {
            listOfContainer.Items.Clear();
            var sessList = Data.VDB.ListSessions();
            foreach (var info in sessList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Name = info.UUID;
                lvi.Text = info.SessionName;
                listOfContainer.Items.Add(lvi);
            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            if (coName.Text.Length < 1) return;
            string UUID = System.Guid.NewGuid().ToString("N");
            var ssInfo = new Data.SessionInfo()
            {
                SessionName = coName.Text,
                UUID = UUID,
                SessionPath = Data.VDB.GetSessionSavePath(UUID),
                Url = Data.VDB.defaultUrl,
                Extentions = new string[0]
            };
            MessageBox.Show("[" + ssInfo.SessionName + "]\n" +
                "UUID:" + ssInfo.UUID + "\n" +
                "PATH:" + ssInfo.SessionPath,
                "正在创建新会话");
            Data.VDB.PutSessionInfo(ssInfo);
            RefreshList();
        }

        private void OpenNewWindow(string UUID)
        {
            BrowserWindow bw = new BrowserWindow(Data.VDB.ReadSessionInfo(Data.VDB.GetSessionSavePath(UUID)));
            openWindows.Add(bw);
            bw.Show();
        }

        private void listOfContainer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenNewWindow(listOfContainer.SelectedItems[0].Name);
        }

        private void 新窗口OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewWindow(listOfContainer.SelectedItems[0].Name);
        }

        private void 显示所有ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关闭所有CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ContainerItemMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 全局用户脚本UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExtentionManager(new Data.SessionInfo() { UUID = "GLOBAL", SessionName = "全局" }).ShowDialog();
        }

        private void 用户脚本UserScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.SessionInfo sinfo = Data.VDB.ReadSessionInfo(
                Data.VDB.GetSessionSavePath(
                    listOfContainer.SelectedItems[0].Name
                    )
                );
            new ExtentionManager(sinfo).ShowDialog();
        }

        private void 打开插件目录ExtentionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Data.VDB.savepath + @"\extentions");
        }

        private void SessionManager_Load(object sender, EventArgs e)
        {

        }

        private void 删除会话DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.SessionInfo sinfo = Data.VDB.ReadSessionInfo(
                Data.VDB.GetSessionSavePath(
                    listOfContainer.SelectedItems[0].Name
                    )
                );
            Data.VDB.DeleteSession(sinfo);
            RefreshList();
        }
    }
}
