using Foundation;
using System;
using UIKit;

namespace Pinned
{
	public partial class LoginPageViewController : UIViewController
	{

		//Create an event when a authentication is successful
		public event EventHandler OnLoginSuccess;

		public LoginPageViewController(IntPtr handle) : base(handle)
		{
		}

	partial void SignUpButton_TouchUpInside(UIButton sender)
	{
		//Create an instance of our AppDelegate
		var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

		//Get an instance of our MainStoryboard.storyboard
		var mainStoryboard = appDelegate.MainStoryboard;

		//Get an instance of our MainTabBarViewController
		var mainTabBarViewController = appDelegate.GetViewController(mainStoryboard, "MainTabBarController");

		//Set the MainTabBarViewController as our RootViewController
		appDelegate.SetRootViewController(mainTabBarViewController, true);
	}

		partial void LoginButton_TouchUpInside(UIButton sender)
		{
			//Validate our Username & Password.
			//This is usually a web service call.
			if (IsUserNameValid() && IsPasswordValid())
			{
				//We have successfully authenticated a the user,
				//Now fire our OnLoginSuccess Event.
				if (OnLoginSuccess != null)
				{
					OnLoginSuccess(sender, new EventArgs());
				}
			}
			else
			{
				new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
			}
		}

		private bool IsUserNameValid()
		{
			return !String.IsNullOrEmpty(UserNameTextView.Text.Trim());
		}

		private bool IsPasswordValid()
		{
			return !String.IsNullOrEmpty(PasswordTextView.Text.Trim());
		}
	}
}