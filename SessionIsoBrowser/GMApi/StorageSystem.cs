using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionIsoBrowser.GMApi
{
    class StorageSystem
    {
        public static Dictionary<string, StorageSystem> storages = new Dictionary<string, StorageSystem>();

        public StorageSystem(string CID)
        {
            storages.Add(CID, this);
        }

        public struct Listener
        {
            public string data;
            public string ID;
            public CefSharp.IJavascriptCallback callback;
        }

        public struct Resource
        {
            public string url;
            public string content;
        }

        public Dictionary<string, Resource> preLoadResources = new Dictionary<string, Resource>();
        public Dictionary<string, string> valueStorage = new Dictionary<string, string>();
        public Dictionary<string, Listener> valueChangeListeners = new Dictionary<string, Listener>();
    }
}
