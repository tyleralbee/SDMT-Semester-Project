using Foundation;
using System;
using UIKit;
using System.Diagnostics;

namespace PinnedApp.iOS
{
    public partial class LoginView : UIViewController
    {
        Universal login;

        public LoginView(IntPtr handle) : base(handle)
        {
            login = new Universal();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }


        async void LoginButton()
        {
            bool sucess = await login.loginUser(txtUsername.Text, txtPassword.Text);
            Debug.WriteLine("AAAccess token: {0}", login.user.AccessToken);
            if (sucess)
            {
                PerformSegue("SucessLoginSegue", this);
            } else
            {
                Debug.WriteLine("Failed to login");
            }
        }

        partial void BtnLogin_TouchUpInside(UIButton sender)
        {
            LoginButton();
        }
        partial void BtnSignup_TouchUpInside(UIButton sender)
        {
            PerformSegue("SegueSignup", this);
        }


    }
}