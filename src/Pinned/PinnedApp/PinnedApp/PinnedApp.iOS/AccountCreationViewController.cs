using Foundation;
using System;
using UIKit;
using System.Diagnostics;

namespace PinnedApp.iOS
{
    public partial class AccountCreationViewController : UIViewController
    {
        Universal login;
        public AccountCreationViewController (IntPtr handle) : base (handle)
        {
             login = new Universal();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
        }

        partial void BtnCreate_TouchUpInside(UIButton sender)
        {
            Debug.WriteLine("Username: {0}", txtSignupUsername.Text);
            login.createUser(txtSignupUsername.Text, txtSignupPassword.Text, txtSignupEmail.Text, txtSignupFirstname.Text, txtSignupLastname.Text);
        }

        partial void BtnConfirm_TouchUpInside(UIButton sender)
        {
            login.confirmUser(txtSignupUsername.Text, txtSignupPassword.Text, txtSignupEmail.Text, txtSignupFirstname.Text, txtSignupLastname.Text, txtSignupConfirm.Text);
        }
    }
}