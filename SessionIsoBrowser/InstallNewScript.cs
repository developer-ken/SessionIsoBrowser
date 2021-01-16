using SessionIsoBrowser.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class InstallNewScript : Form
    {
        SessionInfo session;
        public InstallNewScript(SessionInfo session, string Url)
        {
            this.session = session;
            InitializeComponent();
            code.Text = ScriptFetchEngine.GetScriptContent(Url);
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
                LocalUserScriptHandler.InstallGlobaly(code.Text);
            }
            else
            {
                new LocalUserScriptHandler(session).Install(code.Text);
            }
            this.Close();
        }
    }
}
