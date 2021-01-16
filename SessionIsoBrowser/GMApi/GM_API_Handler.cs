using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SessionIsoBrowser.GMApi
{
    class GM_API_Handler
    {
        Dictionary<string, string> valueStorage = new Dictionary<string, string>();
        public void setValue(string key, string value)
        {
            if (valueStorage.ContainsKey(key)) valueStorage[key] = value;
            else valueStorage.Add(key, value);
        }

        public string getValue(string key, string val = null)
        {
            if (valueStorage.ContainsKey(key)) return valueStorage[key];
            else return val;
        }

        public struct XHRResult
        {
            public int status;
            public string responseText;
        }

        private void WriteRequestStream(HttpWebRequest req, string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);//把字符串转换为字节
            req.ContentLength = data.Length; //请求长度
            using (Stream reqStream = req.GetRequestStream()) //获取
            {
                reqStream.Write(data, 0, data.Length);//向当前流中写入字节
                reqStream.Close(); //关闭当前流
            }
        }

        public void xmlhttpRequest(Dictionary<string, object> variables)
        {
            if (!variables.ContainsKey("url")) throw new Exception("参数不全，撤退！");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(variables["url"].ToString());
            CefSharp.IJavascriptCallback onLoad = null;
            CefSharp.IJavascriptCallback onTimeout = null;
            foreach (KeyValuePair<string, object> kvp in variables)
            {
                switch (kvp.Key)
                {
                    case "method":
                        request.Method = kvp.Value.ToString();
                        break;
                    case "headers":
                        Dictionary<string, string> headers = (Dictionary<string, string>)kvp.Value;
                        foreach (KeyValuePair<string, string> item in headers)
                        {
                            switch (item.Key.ToLower())
                            {
                                case "refer":
                                    request.Referer = item.Value;
                                    break;
                                case "user-agent":
                                    request.UserAgent = item.Value;
                                    break;
                                case "content-type":
                                    request.ContentType = item.Value;
                                    break;
                                default:
                                    if (request.Headers.AllKeys.Contains(item.Key))
                                    {
                                        request.Headers[item.Key] = item.Value;
                                    }
                                    else
                                    {
                                        request.Headers.Add(item.Key, item.Value);
                                    }
                                    break;
                            }
                        }
                        break;
                    case "timeout":
                        request.Timeout = (int)kvp.Value;
                        break;
                    case "onLoad":
                        onLoad = (CefSharp.IJavascriptCallback)kvp.Value;
                        break;
                    case "onTimeout":
                        onTimeout = (CefSharp.IJavascriptCallback)kvp.Value;
                        break;
                    case "data":
                        WriteRequestStream(request, kvp.Value.ToString());
                        break;
                }
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                Stream stream = resp.GetResponseStream();
                string result;
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                XHRResult res = new XHRResult()
                {
                    status = (int)resp.StatusCode,
                    responseText = result
                };
                if (onLoad != null) onLoad.ExecuteAsync(res);
            }
            catch (WebException ex)
            {
                HttpWebResponse resp = (HttpWebResponse)ex.Response;
                XHRResult res = new XHRResult()
                {
                    status = (int)resp.StatusCode,
                    responseText = ""
                };
                if (resp.StatusCode == HttpStatusCode.RequestTimeout ||
                    resp.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    if (onTimeout != null) onTimeout.ExecuteAsync();
                }
                else
                {
                    if (onLoad != null) onLoad.ExecuteAsync(res);
                }
            }
        }
    }
}
