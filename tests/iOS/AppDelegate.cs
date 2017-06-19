using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ProgressRingControl.Forms.Plugin.iOS;
using UIKit;

namespace TestProgressRing.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());
            ProgressRingRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
