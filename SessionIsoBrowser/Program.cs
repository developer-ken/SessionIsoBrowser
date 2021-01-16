using SessionIsoBrowser.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("cef.pak"))
            {
                MessageBox.Show("浏览器渲染引擎未安装。请将RenderEngine复制到当前文件夹，然后重新启动本程序。", "无法启动引擎", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Directory.CreateDirectory(VDB.savepath + @"\extentions");
            Directory.CreateDirectory(VDB.savepath + @"\userscripts");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SessionManager());
        }
    }
}
