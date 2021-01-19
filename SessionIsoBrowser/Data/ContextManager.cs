using CefSharp;
using SessionIsoBrowser.GMApi;
using System.Collections.Generic;

namespace SessionIsoBrowser.Data
{
    class ContextManager
    {
        public struct Context
        {
            public RequestContext context;
        }
        private static Dictionary<string, Context> contList = new Dictionary<string, Context>();
        private static GMApi.ExtensionHandler extHandler = new GMApi.ExtensionHandler();
        public static Context GetContext(string UUID)
        {
            if (contList.ContainsKey(UUID)) return contList[UUID];
            else
            {
                var settings = new RequestContextSettings();
                settings.CachePath = System.IO.Path.GetFullPath(VDB.GetSessionSavePath(UUID));
                settings.PersistSessionCookies = true;
                RequestContext reqc = new RequestContext(settings);
                reqc.LoadExtensionsFromDirectory(VDB.savepath + @"\extentions", extHandler);
                //Cef.RefreshWebPlugins();
                Context c = new Context() { context = reqc};
                contList.Add(UUID, c);
                return c;
            }
        }
    }

    class CM : ContextManager { }
}
