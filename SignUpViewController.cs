using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Pinned
{
	partial class SignUpViewController : UIViewController
	{
		public SignUpViewController(IntPtr handle) : base(handle)
		{
		}


		//This assumes we have successfully create a new user account
		//Naturally, you'll add your logic here, but we're ignoring
		//that for simplicity.


		partial void CancelButton_TouchUpInside(UIButton sender)
		{
			DismissViewController(true, null);
		}
	}
}