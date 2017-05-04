using CoreLocation;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace PinnedApp.iOS
{
    public partial class HomePageViewController : UIViewController
    {
        public HomePageViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitMap();
            mapHome.DidUpdateUserLocation += (sender, e) =>
                {
                    if (mapHome.UserLocation != null)
                    {
                        CLLocationCoordinate2D coords = mapHome.UserLocation.Coordinate;
                        MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(2), MilesToLongitudeDegrees(2, coords.Latitude));
                        mapHome.Region = new MKCoordinateRegion(coords, span);
                    }
                };

        }

        private void InitMap()
        {

            CLLocationCoordinate2D coords = mapHome.UserLocation.Coordinate;
            MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(20), MilesToLongitudeDegrees(20, coords.Latitude));

            mapHome.Region = new MKCoordinateRegion(coords, span);
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
        public double MilesToLatitudeDegrees(double miles)
        {
            double earthRadius = 3960.0; //in miles
            double radiansToDegrees = 180.0 / Math.PI;
            return (miles / earthRadius) * radiansToDegrees;
        }
        public double MilesToLongitudeDegrees(double miles, double atLatitude)
        {
            double earthRadius = 3960.0; //in miles
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            //derive the earth's radius at theat point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (miles / radiusAtLatitude) * radiansToDegrees;
        }
    }
}