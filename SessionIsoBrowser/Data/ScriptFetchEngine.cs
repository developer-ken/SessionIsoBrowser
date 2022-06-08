using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace SessionIsoBrowser.Data
{
    class ScriptFetchEngine
    {
        public static string GetScriptContent(string Url,SessionInfo session = new SessionInfo())
        {
            try
            {
                string retString = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.64 Safari/537.36 Edg/101.0.1210.53 SIB";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myResponseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch(Exception err)
            {
                return "资源不可用：\n"+err.Message;
            }
        }
    }
}
