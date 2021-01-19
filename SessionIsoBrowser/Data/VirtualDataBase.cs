using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SessionIsoBrowser.Data
{
    public struct SessionInfo
    {
        public string UUID;
        public string SessionPath;
        public string SessionName;
        public string Url;
        public string[] Userscripts;
    }
    class VirtualDataBase
    {
        public static string savepath
        {
            get
            {
                return Properties.Settings.Default.savePath + @"\";
            }
        }

        public static string UserAgent
        {
            get
            {
                return Properties.Settings.Default.UserAgent;
            }
            set
            {
                Properties.Settings.Default.UserAgent = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string defaultUrl
        {
            get
            {
                return Properties.Settings.Default.defaultUrl;
            }
            set
            {
                Properties.Settings.Default.defaultUrl = value;
                Properties.Settings.Default.Save();
            }
        }

        public static List<string> GlobalUserScripts
        {
            get
            {
                if (Properties.Settings.Default.UserScripts == null) Properties.Settings.Default.UserScripts = new System.Collections.Specialized.StringCollection();
                return Properties.Settings.Default.UserScripts.Cast<string>().ToList();
            }
            set
            {
                Properties.Settings.Default.UserScripts.Clear();
                Properties.Settings.Default.UserScripts.AddRange(value.ToArray());
                Properties.Settings.Default.Save();
            }
        }

        public static string GetSessionSavePath(string UUID)
        {
            return savepath + @"\" + UUID;
        }

        public static List<string> GetSessionRelatedScripts(string UUID)
        {
            string[] localExtentions = ReadSessionInfo(GetSessionSavePath(UUID)).Userscripts;
            //将两个集合合并作为结果
            List<string> userscripts = new List<string>();
            userscripts.AddRange(GlobalUserScripts);
            userscripts.AddRange(localExtentions);
            return userscripts;
        }

        public static void DeleteSession(SessionInfo session)
        {
            try
            {
                Directory.Delete(session.SessionPath, true);
            }
            catch{
                Properties.Settings.Default.FolderToDelete.Add(session.SessionPath);
            }
            Properties.Settings.Default.SessionList.Remove(session.UUID);
        }

        public static List<SessionInfo> ListSessions()
        {
            var slist = Properties.Settings.Default.SessionList;
            List<SessionInfo> sinfo = new List<SessionInfo>();
            if (slist == null) return sinfo;//列表未初始化，无需遍历
            foreach (string uuid in slist)
            {
                try
                {
                    sinfo.Add(ReadSessionInfo(GetSessionSavePath(uuid)));
                }
                catch (Exception err)
                {
                    Trace.WriteLine(err.Message);
                }
            }
            return sinfo;
        }

        public static SessionInfo ReadSessionInfo(string sessionPath)
        {
            string[] data = File.ReadAllText(sessionPath + @"\SessionInfo.sib.db").Split('\n');
            SessionInfo si = new SessionInfo
            {
                SessionPath = sessionPath,
                UUID = data[1],
                SessionName = data[2],
                Url = data[3],
                Userscripts = data.Skip<string>(4).ToArray()
            };
            return si;
        }

        public static void PutSessionInfo(SessionInfo sessionInfo)
        {
            Directory.CreateDirectory(sessionInfo.SessionPath);
            StringBuilder sb = new StringBuilder();
            foreach (string line in sessionInfo.Userscripts)
            {
                sb.Append(line + "\n");
            }
            File.WriteAllText(sessionInfo.SessionPath + @"\SessionInfo.sib.db",
                "SessionIsoBrowser(SIB) Session Data File ver 0.1\n" +
                sessionInfo.UUID + "\n" +
                sessionInfo.SessionName + "\n" +
                sessionInfo.Url + "\n" +
                sb.ToString());
            if (Properties.Settings.Default.SessionList == null)
                Properties.Settings.Default.SessionList = new System.Collections.Specialized.StringCollection();
            if (!Properties.Settings.Default.SessionList.Contains(sessionInfo.UUID))
                Properties.Settings.Default.SessionList.Add(sessionInfo.UUID);
            Properties.Settings.Default.Save();
        }
    }

    class VDB : VirtualDataBase { }//别名缩写
}
