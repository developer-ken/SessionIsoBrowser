using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SessionIsoBrowser.Data
{
    class UserScript
    {
        public string JSCode;
        public UserScriptConfig conf;
        public Regex[] sites;

        public struct UserScriptConfig
        {
            public string Name, Version, NameSpace, Description, Author, License;
            public string[] Match, Grant;
            public Dictionary<string, string> Resources;
            public List<KeyValuePair<string, string>> UnidentifiedArgs;
        }

        public UserScript(string code)
        {
            JSCode = code;
            conf = GetUserScriptConfig();
            List<Regex> ss = new List<Regex>();
            foreach (string regex in conf.Match)
            {
                ss.Add(new Regex(regex.Replace(".", "\\.").Replace("*", ".*")));
            }
            sites = ss.ToArray();
        }

        public string GetUserScriptConfigStr()
        {
            Regex reg = new Regex("==UserScript==.*==/UserScript==", RegexOptions.Singleline);
            return reg.Match(JSCode).Value;
        }

        public UserScriptConfig GetUserScriptConfig()
        {
            if (conf.Name != null) return conf;
            string[] lines = GetUserScriptConfigStr().Split('\n');
            List<string> match = new List<string>();
            List<string> grant = new List<string>();
            Dictionary<string, string> resources = new Dictionary<string, string>();
            UserScriptConfig res = new UserScriptConfig();
            res.UnidentifiedArgs = new List<KeyValuePair<string, string>>();
            foreach (string line in lines)
            {
                if (!Regex.IsMatch(line, "(// *)(@[\\w-]{1,})( {1,})(.{1,})")) continue;//不是正确的指令格式
                var caps = Regex.Match(line, "// *(@[\\w-]{1,}) {1,}(.{1,})").Groups;
                string cmd = caps[1].Value;
                string value = caps[2].Value;
                switch (cmd)
                {
                    case "@name":
                        res.Name = value;
                        break;
                    case "@author":
                        res.Author = value;
                        break;
                    case "@description":
                        res.Description = value;
                        break;
                    case "@namespace":
                        res.NameSpace = value;
                        break;
                    case "@match":
                        match.Add(value);
                        break;
                    case "@grant":
                        grant.Add(value);
                        break;
                    case "@license":
                        res.License = value;
                        break;
                    case "@resource":
                        var recaps = Regex.Match(value, "(\\w{1,}) {1,}(.{1,}/.{1,})").Groups;
                        resources.Add(recaps[1].Value, recaps.Count == 3 ? recaps[2].Value : "");
                        break;
                    default:
                        res.UnidentifiedArgs.Add(new KeyValuePair<string, string>(cmd, value));
                        break;
                }
            }
            res.Match = match.ToArray();
            res.Grant = grant.ToArray();
            res.Resources = resources;
            return res;
        }

        public bool IsAvailableInPage(string url)
        {
            foreach (Regex reg in sites)
            {
                if (reg.IsMatch(url)) return true;
            }
            return false;
        }
    }
}
