// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PinnedApp.iOS
{
    [Register ("AccountCreationViewController")]
    partial class AccountCreationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnConfirm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCreate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SignupPage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupConfirm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupFirstname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupLastname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSignupUsername { get; set; }

        [Action ("BtnConfirm_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnConfirm_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnCreate_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCreate_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnConfirm != null) {
                btnConfirm.Dispose ();
                btnConfirm = null;
            }

            if (btnCreate != null) {
                btnCreate.Dispose ();
                btnCreate = null;
            }

            if (SignupPage != null) {
                SignupPage.Dispose ();
                SignupPage = null;
            }

            if (txtSignupConfirm != null) {
                txtSignupConfirm.Dispose ();
                txtSignupConfirm = null;
            }

            if (txtSignupEmail != null) {
                txtSignupEmail.Dispose ();
                txtSignupEmail = null;
            }

            if (txtSignupFirstname != null) {
                txtSignupFirstname.Dispose ();
                txtSignupFirstname = null;
            }

            if (txtSignupLastname != null) {
                txtSignupLastname.Dispose ();
                txtSignupLastname = null;
            }

            if (txtSignupPassword != null) {
                txtSignupPassword.Dispose ();
                txtSignupPassword = null;
            }

            if (txtSignupUsername != null) {
                txtSignupUsername.Dispose ();
                txtSignupUsername = null;
            }
        }
    }
}