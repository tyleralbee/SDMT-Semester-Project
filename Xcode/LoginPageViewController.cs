using Foundation;
using System;
using UIKit;

namespace Pinned
{
    public partial class LoginPageViewController : UIViewController
    {
        public LoginPageViewController (IntPtr handle) : base (handle)
        {
        }
		private bool isSignUpValid()
		{
			return true;
		}
		public event EventHandler onSignUpSuccess;
		private bool IsUserNameValid()
		{
			return !String.IsNullOrEmpty(UserNameTextView.Text.Trim());
		}
		public event EventHandler OnLoginSuccess;

		private bool IsPasswordValid()
		{
			return !String.IsNullOrEmpty(PasswordTextView.Text.Trim());
		}
		partial void LoginButton_TouchUpInside(UIButton sender)
        {
            //Validate our Username & Password.
            //This is usually a web service call.
            if(IsUserNameValid() && IsPasswordValid())
            {
                //We have successfully authenticated a the user,
                //Now fire our OnLoginSuccess Event.
                if(OnLoginSuccess != null)
                {

					OnLoginSuccess(sender, new EventArgs());
                }
            }
            else
            {
                new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
            }
		}

		partial void SignUpButton_TouchUpInside(UIButton sender)
		{
	if (isSignUpValid())
	{
		//We have successfully authenticated a the user,
		//Now fire our OnLoginSuccess Event.
		if (onSignUpSuccess != null)
		{

			onSignUpSuccess(sender, new EventArgs());
		}
	}
	else
	{
		new UIAlertView("Login Error", "Bad user name or password", null, "OK", null).Show();
	}
	//Create an instance of our AppDelegate
	var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

	//Get an instance of our MainStoryboard.storyboard
	var mainStoryboard = appDelegate.MainStoryboard;

	//Get an instance of our MainTabBarViewController
	var mainTabBarViewController = appDelegate.GetViewController(mainStoryboard, "SignUpPageViewController");

			//Set the MainTabBarViewController as our RootViewController
			appDelegate.SetRootViewController(mainTabBarViewController, true);
}
	}
}