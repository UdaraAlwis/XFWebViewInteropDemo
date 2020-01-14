using System;
using Android.Webkit;
using Java.Interop;
using XFWebViewInteropDemo.Controls;

namespace XFWebViewInteropDemo.Droid.Renderers
{
    public class JsBridge : Java.Lang.Object
    {
        readonly WeakReference<HybridWebViewRenderer> HybridWebViewMainRenderer;

        public JsBridge(HybridWebViewRenderer hybridRenderer)
        {
            HybridWebViewMainRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            if (HybridWebViewMainRenderer != null && HybridWebViewMainRenderer.TryGetTarget(out var hybridRenderer))
            {
                ((HybridWebView)hybridRenderer.Element).InvokeAction(data);
            }
        }
    }
}