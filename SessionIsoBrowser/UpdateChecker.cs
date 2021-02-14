using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionIsoBrowser
{
    public partial class UpdateChecker : Form
    {
        public static Version version;
        public UpdateInfo update;
        bool needUpdate = false;
        public string checkUrl = "https://storage.microstorm.tech/sib_repo/update.json";

        public struct UpdateInfo
        {
            public string desc, url, hash;
            public Version current, latest, last_vital;
            public bool isVital;
        }

        public UpdateChecker(string jsonUrl,Version current)
        {
            version = current;
            checkUrl = jsonUrl;
            InitializeComponent();
        }

        private void UpdateChecker_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "当前：" + version.ToString() + "(" + version.ToString() + ")\n正在寻找更新程式...";
            CheckForIllegalCrossThreadCalls = false;
            new Thread(new ThreadStart(() =>
            {
                try
                {
                    string jstring = Get(checkUrl);
                    JObject jb = JObject.Parse(jstring);
                    Version latest = Version.Parse(jb.Value<string>("ver"));
                    Version lastvital = Version.Parse(jb.Value<string>("last-vital"));
                    update = new UpdateInfo()
                    {
                        current = version,
                        desc = jb.Value<string>("desc"),
                        isVital = jb.Value<bool>("vital") || lastvital > version,
                        url = jb.Value<string>("url"),
                        last_vital = lastvital,
                        latest = latest,
                        hash = jb.Value<string>("hash"),
                    };
                    if (latest > version)
                    {
                        richTextBox1.Text =
                        "当前：" + version.ToString() + "\n" +
                        "最新：" + latest.ToString() + "\n" +
                        (update.isVital ? "⚠您正在使用的版本缺失关键功能或补丁，请尽快更新！" : "ℹ这是一个可选更新，能够优化部分用户的体验。") + "\n" +
                        "[双击这里开始更新]\n" +
                        "更新日志:\n" + update.desc;
                        needUpdate = true;
                    }
                    else
                    {
                        needUpdate = false;
                        richTextBox1.Text =
                        "当前：" + version.ToString() + "\n" +
                        "最新：" + latest.ToString() + "\n" +
                        "ℹ您的版本已经是最新。\n" +
                        "当前版本:\n" + update.desc;
                    }
                }
                catch (Exception err)
                {
                    richTextBox1.Text = "当前：" + version.ToString() + "(" + version.ToString() + ")\n无法检测更新：" + err.Message + "\nStackTrace:\n" + err.StackTrace;
                }
            })).Start();
        }

        public static string Get(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            if (req == null || req.GetResponse() == null)
                return string.Empty;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            if (resp == null)
                return string.Empty;

            using (Stream stream = resp.GetResponseStream())
            {
                //获取内容
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void Download(string url, string savePath)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            if (req == null || req.GetResponse() == null)
                return;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            if (resp == null)
                return;

            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }

            FileStream fs = File.OpenWrite(savePath);

            using (Stream stream = resp.GetResponseStream())
            {
                stream.CopyTo(fs);
            }
            fs.Flush();
            fs.Close();
        }

        bool isUpdateRunning = false;

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            if (needUpdate && !isUpdateRunning)
                new Thread(new ThreadStart(() =>
                {
                    isUpdateRunning = true;
                    richTextBox1.Text = "更新到版本:" + update.latest + "\n" +
                      "准备更新包...\n";
                    Download(update.url, "update.zip");
                    if (File.Exists("update.zip"))
                    {
                        if (update.hash.Length > 1)
                        {
                            string fhash = HashHelper.ComputeCRC32("update.zip");
                            if (fhash.ToUpper() != update.hash.ToUpper())
                            {
                                richTextBox1.Text += "CRC32校验失败，更新包损坏，请稍后重试。\n";
                                File.Delete("update.zip");
                                isUpdateRunning = false;
                                return;
                            }
                        }
                        else
                        {
                            richTextBox1.Text += "Warning: 远程服务器关闭CRC32校验，可能存在安全隐患\n";
                        }
                        //继续更新
                        Process.Start("UpdateInstaller.exe", Process.GetCurrentProcess().Id.ToString());
                        richTextBox1.Text += "等待更新安装程序接管...\n";
                    }
                    else
                    {
                        richTextBox1.Text += "更新包下载失败，请稍后重试。\n";
                    }
                    isUpdateRunning = false;
                })).Start();
        }
    }
}
