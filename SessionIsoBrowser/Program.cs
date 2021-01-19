using CefSharp;
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
            if (!File.Exists("SessionIsoBrowser.exe.config"))
            {
                MessageBox.Show("默认配置文件丢失，请将全部相关文件复制到同一文件夹内。", "无法加载配置文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Directory.CreateDirectory(VDB.savepath + @"\extentions");
            Directory.CreateDirectory(VDB.savepath + @"\userscripts");
            if (Properties.Settings.Default.UserScripts == null) Properties.Settings.Default.UserScripts = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.FolderToDelete == null) Properties.Settings.Default.FolderToDelete = new System.Collections.Specialized.StringCollection();
            else if (Properties.Settings.Default.FolderToDelete.Count > 0)
            {
                foreach(string path in Properties.Settings.Default.FolderToDelete)
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch { }
                }
                Properties.Settings.Default.FolderToDelete.Clear();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SessionManager());
            Cef.Shutdown();
            if (Properties.Settings.Default.FolderToDelete.Count > 0)
            {
                foreach (string path in Properties.Settings.Default.FolderToDelete)
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch { }
                }
                Properties.Settings.Default.FolderToDelete.Clear();
            }
        }
    }
}
