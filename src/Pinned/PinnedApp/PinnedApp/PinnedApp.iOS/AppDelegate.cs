using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace PinnedApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]

    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        UIWindow window;
        public static UIStoryboard Storyboard = UIStoryboard.FromName("Login", null);
        public static UIViewController initialViewController;
        /// <summary>
        /// After app has launched this function is ran, we intiate our storyboard here
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            initialViewController = Storyboard.InstantiateInitialViewController() as LoginView;

            window.RootViewController = initialViewController;
            window.MakeKeyAndVisible();
            return true;
        }

    }
}
