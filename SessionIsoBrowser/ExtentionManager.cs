using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class ExtentionManager : Form
    {
        Data.SessionInfo session;
        public ExtentionManager(Data.SessionInfo session)
        {
            this.session = session;
            InitializeComponent();
            Text = "脚本管理器 - " + Properties.Settings.Default.Title;
            noticePad.Text = "* 正在编辑 " + session.SessionName + " 的脚本设置    关闭窗口自动保存";
            StringBuilder sb = new StringBuilder();
            if (session.UUID == "GLOBAL") session.Extentions = Data.VDB.GlobalExtentions.ToArray();
            foreach (string url in session.Extentions)
            {
                try
                {
                    new Uri(url);//检测是否合法
                    sb.Append(url + "\n");
                }
                catch (UriFormatException) { }
            }
            userScriptBox.Text = sb.ToString();
        }

        private void UserScriptManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> str = userScriptBox.Text.Split('\n').ToList();
            str.RemoveAll(Invalid);//移除非有效URL的行
            if (session.UUID == "GLOBAL")
            {
                Data.VDB.GlobalExtentions = str;
            }
            else
            {
                session.Extentions = str.ToArray();
                Data.VDB.PutSessionInfo(session);
            }
        }

        private bool Invalid(string line)
        {
            try
            {
                new Uri(line);
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
