using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace UpdateInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SIB 离线更新程序");
            try
            {
                Process p = Process.GetProcessById(int.Parse(args[0]));
                p.Kill();
            }
            catch (Exception err)
            {
                Console.WriteLine("无法结束SIB进程：" + err.Message);
            }
            if (!File.Exists("update.zip"))
            {
                Console.WriteLine("更新失败：找不到更新包");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("解压更新包...");
            var res = ExtractZip("update.zip", "./");
            foreach (string line in res)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("处理了" + res.Count + "个文件。");
            Console.WriteLine("等待SIB主进程接管...");
            Process.Start("SessionIsoBrowser.exe", "--update-done");
            Thread.Sleep(2000);
            return;
        }

        static List<string> ExtractZip(string zipFilePath, string destPath)
        {
            var zip = ZipFile.OpenRead(zipFilePath);
            List<string> resu = new List<string>();
            foreach (var ent in zip.Entries)
            {
                ent.ExtractToFile(ent.FullName, true);
                resu.Add(ent.FullName);
            }
            zip.Dispose();
            return resu;
        }
    }
}
