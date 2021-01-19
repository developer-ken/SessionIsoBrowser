using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SessionIsoBrowser.Data
{
    class LocalUserScriptHandler
    {
        private SessionInfo session;
        public LocalUserScriptHandler(SessionInfo session)
        {
            this.session = session;
        }

        public string Install(string Code)
        {
            UserScript script = new UserScript(Code);
            string HASH = GetHashString(script.conf.Name);
            Directory.CreateDirectory(session.SessionPath + @"\userscripts\");
            File.WriteAllText(session.SessionPath + @"\userscripts\" + HASH + ".user.js", script.JSCode);
            List<string> scripts = session.Userscripts.ToList();
            scripts.Add("localscript://" + HASH + "/" + script.conf.Name);
            session.Userscripts = scripts.ToArray();
            Data.VDB.PutSessionInfo(session);
            return HASH;
        }

        public static string InstallGlobaly(string Code)
        {
            UserScript script = new UserScript(Code);
            string HASH = GetHashString(script.conf.Name);
            File.WriteAllText(VDB.savepath + @"\userscripts\" + HASH + ".user.js", script.JSCode);
            Properties.Settings.Default.UserScripts.Add("globalscript://" + HASH + "/" + script.conf.Name);
            return HASH;
        }

        public UserScript GetLocalUserScript(string HASH)
        {
            return new UserScript(File.ReadAllText(session.SessionPath + @"\userscripts\" + HASH + ".user.js"));
        }

        public static UserScript GetUserScript(string HASH)
        {
            return new UserScript(File.ReadAllText(VDB.savepath + @"\userscripts\" + HASH + ".user.js"));
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
