using System.IO;
using System.Net;

namespace SessionIsoBrowser.Data
{
    class ScriptFetchEngine
    {
        public static string GetScriptContent(string Url)
        {
            try
            {
                string retString = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myResponseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch
            {
                return "";
            }
        }

    }
}
