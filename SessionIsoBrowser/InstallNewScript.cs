using SessionIsoBrowser.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class InstallNewScript : Form
    {
        SessionInfo session;
        bool loaded = false;
        string url;
        public InstallNewScript(SessionInfo session, string Url)
        {
            this.session = session;
            url = Url;
            loaded = false;
            InitializeComponent();
            Task.Run(async () =>
            {
                button1.Text = "安装引用";
                code.Text = "正在下载脚本代码\n\n加载完成后您可以编辑代码并保存，脚本加载时将从您的硬盘加载。\n如果您直接点击安装，脚本将在每次被使用时从网络加载。";
                code.Text = ScriptFetchEngine.GetScriptContent(HttpUtility.UrlDecode(Url));
                loaded = true;
                button1.Text = "安装";
            });
        }

        private void InstallNewScript_Load(object sender, EventArgs e)
        {
            selecttarget.Items.Clear();
            selecttarget.Items.Add("[全局]");
            selecttarget.Items.Add(session.SessionName);
            selecttarget.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selecttarget.SelectedIndex == 0)
            {
                if (loaded)
                    LocalUserScriptHandler.InstallGlobaly(code.Text);
                else
                    Data.VDB.GlobalUserScripts.Add(url);
            }
            else
            {
                if (loaded)
                    new LocalUserScriptHandler(session).Install(code.Text);
                else
                {
                    List<string> s = session.Userscripts.ToList();
                    s.Add(url);
                    session.Userscripts = s.ToArray();
                    Data.VDB.PutSessionInfo(session);
                }
            }
            this.Close();
        }
    }
}
