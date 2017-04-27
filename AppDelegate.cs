using Foundation;
using UIKit;
using System;

namespace Pinned
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		private bool isAuthenticated = false;

		public override UIWindow Window
		{
			get;
			set;
		}
		//Public property to access our MainStoryboard.storyboard file
		public UIStoryboard MainStoryboard
		{
			get { return UIStoryboard.FromName("MainStoryboard", NSBundle.MainBundle); }
		}

		//Creates an instance of viewControllerName from storyboard
		public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
		{
			return storyboard.InstantiateViewController(viewControllerName);
		}

		//Sets the RootViewController of the Apps main window with an option for animation.
		public void SetRootViewController(UIViewController rootViewController, bool animate)
		{
			if (animate)
			{
				var transitionType = UIViewAnimationOptions.TransitionFlipFromRight;

				Window.RootViewController = rootViewController;
				UIView.Transition(Window, 0.5, transitionType,
								  () => Window.RootViewController = rootViewController,
								  null);
			}
			else
			{
				Window.RootViewController = rootViewController;
			}
		}

		//Override FinishedLaunching. This executes after the app has started.
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			//isAuthenticated can be used for an auto-login feature, you'll have to implement this
			//as you see fit or get rid of the if statement if you want.
			if (isAuthenticated)
			{
				//We are already authenticated, so go to the main tab bar controller;
				var tabBarController = GetViewController(MainStoryboard, "MainTabBarController");
				SetRootViewController(tabBarController, false);
			}
			else
			{
				//User needs to log in, so show the Login View Controlller
				var loginViewController = GetViewController(MainStoryboard, "LoginPageViewController") as LoginPageViewController;
				loginViewController.OnLoginSuccess += LoginViewController_OnLoginSuccess;
				SetRootViewController(loginViewController, false);
			}

			return true;
		}

		void LoginViewController_OnLoginSuccess(object sender, EventArgs e)
		{
			//We have successfully Logged In
			var tabBarController = GetViewController(MainStoryboard, "MainTabBarController");
			SetRootViewController(tabBarController, true);
		}

			// Code to start the Xamarin Test Cloud Agent
//#if ENABLE_TEST_CLOUD
//			Xamarin.Calabash.Start();
//#endif

		//	return true;

		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

