using Foundation;
using System;
using UIKit;

namespace PinnedApp.iOS
{
    public partial class PinPopupViewController : UIViewController
    {
        Universal univ;
        public string longi;
        public string lat;


        public PinPopupViewController(IntPtr handle) : base(handle)
        {
        }
        public PinPopupViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            txtLongitude.Text = longi;
            txtLatitude.Text = lat;
        }

        [Action("UnwindPinCreation:")]
        public void UnwindPinCreation(UIStoryboardSegue segue)
        {
            Console.WriteLine("We've unwinded");
        }

        /// <summary>
        /// Button event to take inputed pin data and create new pin in the database
        /// </summary>
        /// <param name="sender"></param>
        partial void BtnCreatePin_TouchUpInside(UIButton sender)
        {

            univ = new Universal();
            univ.createPin(txtTitle.Text, txtDescription.Text, txtLongitude.Text, txtLatitude.Text);
            DismissViewController(true, null);
        }
    }
}