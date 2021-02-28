using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SessionIsoBrowser.GMApi
{
    /// <summary>
    /// 每个窗口拥有一个该实例
    /// 每个会话(容器)共享一个StorageSystem实例
    /// </summary>
    class GM_API_Handler
    {
        string CID;
        public Dictionary<string, string> valueStorage;
        public Dictionary<string, StorageSystem.Listener> valueChangeListeners;
        public StorageSystem storage;
        List<string> myLisener = new List<string>();

        public GM_API_Handler(string ContainerID, BrowserWindow window)
        {
            this.CID = ContainerID;
            if (!StorageSystem.storages.ContainsKey(CID))
            {
                new StorageSystem(CID);
            }
            storage = StorageSystem.storages[CID];
            valueStorage = StorageSystem.storages[CID].valueStorage;
            valueChangeListeners = StorageSystem.storages[CID].valueChangeListeners;
        }

        public void setValue(string key, string value)
        {
            if (valueStorage.ContainsKey(key))
            {
                foreach (StorageSystem.Listener l in valueChangeListeners.Values)
                {
                    if (l.data == key)
                    {
                        l.callback.ExecuteAsync(key, valueStorage[key], value, !myLisener.Contains(l.ID));
                    }
                }
                valueStorage[key] = value;
            }
            else valueStorage.Add(key, value);
        }

        public string getValue(string key, string val = null)
        {
            if (valueStorage.ContainsKey(key)) return valueStorage[key];
            else return val;
        }

        public void deleteValue(string key)
        {
            if (valueStorage.ContainsKey(key)) valueStorage.Remove(key);
        }

        public string[] listValues()
        {
            return valueStorage.Keys.ToArray();
        }

        public string addValueChangeListener(string valueKey, CefSharp.IJavascriptCallback callback)
        {
            var listener = new StorageSystem.Listener()
            {
                data = valueKey,
                callback = callback
            };
            listener.ID = listener.GetHashCode().ToString();
            valueChangeListeners.Add(listener.ID, listener);
            myLisener.Add(listener.ID);
            return listener.ID;
        }

        public void removeValueChangeListener(string listenerID)
        {
            valueChangeListeners.Remove(listenerID);
            if (myLisener.Contains(listenerID))
            {
                myLisener.Remove(listenerID);
            }
        }

        public void log(string text)
        {
            Console.WriteLine(text);
        }

        public string getResourceText(string name)
        {
            if (storage.preLoadResources.ContainsKey(name))
            {
                return storage.preLoadResources[name].content;
            }
            else
            {
                return "";
            }
        }

        public string getResourceURL(string name)
        {
            if (storage.preLoadResources.ContainsKey(name))
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(storage.preLoadResources[name].url));
            }
            else
            {
                return "";
            }
        }

        public void setClipboard(string value)
        {
            Thread recvThread = new Thread(new ThreadStart(() =>
            {
                Clipboard.SetDataObject(value, true);
            }));
            recvThread.SetApartmentState(ApartmentState.STA);
            recvThread.Start();
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

        private Dictionary<string, string> ObjDic2StrDic(Dictionary<string, object> strdic)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (var kvp in strdic)
            {
                res.Add(kvp.Key, (string)kvp.Value);
            }
            return res;
        }

        public void xmlhttpRequest(Dictionary<string, object> variables)
        {
            if (!variables.ContainsKey("url")) throw new Exception("参数不全，撤退！");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(variables["url"].ToString());
            CefSharp.IJavascriptCallback onLoad = null;
            CefSharp.IJavascriptCallback onTimeout = null;
            foreach (KeyValuePair<string, object> kvp in variables)
            {
                switch (kvp.Key.ToLower())
                {
                    case "method":
                        request.Method = kvp.Value.ToString();
                        break;
                    case "headers":
                        Dictionary<string, string> headers = ObjDic2StrDic((Dictionary<string, object>)kvp.Value);
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
                    case "onload":
                        onLoad = (CefSharp.IJavascriptCallback)kvp.Value;
                        break;
                    case "ontimeout":
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
                onLoad?.ExecuteAsync(res);
            }
            catch (WebException ex)
            {
                if (ex.Message.IndexOf("超时") > 0)
                {
                    onTimeout?.ExecuteAsync();
                    return;
                }
                HttpWebResponse resp = (HttpWebResponse)ex.Response;
                XHRResult res = new XHRResult()
                {
                    status = (int)resp.StatusCode,
                    responseText = ""
                };
                if (resp.StatusCode == HttpStatusCode.RequestTimeout ||
                    resp.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    onTimeout?.ExecuteAsync();
                }
                else
                {
                    onLoad?.ExecuteAsync(res);
                }
            }
        }
    }
}
