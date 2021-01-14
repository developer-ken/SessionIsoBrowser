using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionIsoBrowser.GMApi
{
    class ExtensionHandler : IExtensionHandler
    {
        public bool CanAccessBrowser(IExtension extension, IBrowser browser, bool includeIncognito, IBrowser targetBrowser)
        {
            return true;
        }

        public void Dispose()
        {
            return;
        }

        public IBrowser GetActiveBrowser(IExtension extension, IBrowser browser, bool includeIncognito)
        {
            return null;
        }

        public bool GetExtensionResource(IExtension extension, IBrowser browser, string file, IGetExtensionResourceCallback callback)
        {
            return false;
        }

        public bool OnBeforeBackgroundBrowser(IExtension extension, string url, IBrowserSettings settings)
        {
            return false;
        }

        public bool OnBeforeBrowser(IExtension extension, IBrowser browser, IBrowser activeBrowser, int index, string url, bool active, IWindowInfo windowInfo, IBrowserSettings settings)
        {
            return false;
        }

        public void OnExtensionLoaded(IExtension extension)
        {

        }

        public void OnExtensionLoadFailed(CefErrorCode errorCode)
        {
            
        }

        public void OnExtensionUnloaded(IExtension extension)
        {
            
        }
    }
}
