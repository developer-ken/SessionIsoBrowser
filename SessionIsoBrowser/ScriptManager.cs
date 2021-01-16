using SessionIsoBrowser.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class ScriptManager : Form
    {
        Data.SessionInfo session;
        public ScriptManager(Data.SessionInfo session)
        {
            this.session = session;
            InitializeComponent();
            Text = "脚本管理器 - " + Properties.Settings.Default.Title;
            noticePad.Text = "* 正在编辑 " + session.SessionName + " 的脚本设置    关闭窗口自动保存";
            StringBuilder sb = new StringBuilder();
            if (session.UUID == "GLOBAL") session.Userscripts = Data.VDB.GlobalUserScripts.ToArray();
            foreach (string url in session.Userscripts)
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
                Data.VDB.GlobalUserScripts = str;
            }
            else
            {
                session.Userscripts = str.ToArray();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (session.UUID == "GLOBAL")
            {
                Process.Start(VDB.savepath + @"\userscripts");
            }
            else
            {
                Directory.CreateDirectory(session.SessionPath + @"\userscripts");
                Process.Start(session.SessionPath + @"\userscripts");
            }
        }
    }
}
