using Foundation;
using System;
using UIKit;

namespace PinnedApp.iOS
{
    public partial class LoginView : UIViewController
    {
        UIViewController AccountCreation;
        public LoginView (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Universal login = new Universal();
            btnLogin.TouchUpInside += (o, e) =>
            {
                login.loginUser(txtUsername.Text, txtPassword.Text);
            };
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            AccountCreation = Storyboard.InstantiateViewController("AccountCreationViewController") as AccountCreationViewController;
        }



        partial void BtnSignup_TouchUpInside(UIButton sender)
        {
            this.NavigationController.PushViewController(AccountCreation, true);
        }
    }
}