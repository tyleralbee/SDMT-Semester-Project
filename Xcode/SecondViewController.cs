using System;

using UIKit;

namespace Pinned
{
	public partial class SecondViewController : UIViewController
	{

		protected SecondViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		private bool isDropPinValid()
		{
			return true;
		}
		public event EventHandler onDropPinSuccess;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void DropPinButton_TouchUpInside(UIButton sender)
        {
			
            //Validate our Username & Password.
            //This is usually a web service call.
			if(isDropPinValid())
            {
                //We have successfully authenticated a the user,
                //Now fire our OnLoginSuccess Event.
				if(onDropPinSuccess != null)
                {

					onDropPinSuccess(sender, new EventArgs());
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
			var mainTabBarViewController = appDelegate.GetViewController(mainStoryboard, "MainTabBarController");

			//Set the MainTabBarViewController as our RootViewController
			appDelegate.SetRootViewController(mainTabBarViewController, true);
        }
	}
}
