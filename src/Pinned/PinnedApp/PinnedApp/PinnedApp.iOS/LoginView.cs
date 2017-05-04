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

        /// <summary>
        /// This attempts to login user creditials inputed
        /// </summary>
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
        /// <summary>
        /// Button login event, launches async method LoginButton
        /// </summary>
        /// <param name="sender"></param>
        partial void BtnLogin_TouchUpInside(UIButton sender)
        {
            LoginButton();
        }
        /// <summary>
        /// Sends current view to the signup page
        /// </summary>
        /// <param name="sender"></param>
        partial void BtnSignup_TouchUpInside(UIButton sender)
        {
            PerformSegue("SegueSignup", this);
        }


    }
}