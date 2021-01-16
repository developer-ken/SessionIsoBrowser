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
            Directory.CreateDirectory(VDB.savepath + @"\extentions");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SessionManager());
        }
    }
}
