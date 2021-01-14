using CefSharp;
using CefSharp.WinForms;

namespace Common.Control
{
    internal class CefSharpOpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }
        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }
        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }
        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            newBrowser = null;
            return true; //Return true to cancel the popup creation
        }
    }
}