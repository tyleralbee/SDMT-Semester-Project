using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;
using System;
using System.Collections.Generic;
using UIKit;

namespace PinnedApp.iOS
{
    /// <summary>
    /// This is the main page of the app, containing the map
    /// </summary>
    public partial class HomePageViewController : UIViewController
    {

        MKMapView mapView;
        UISegmentedControl mapTypes;
        CLLocationManager locationManager = new CLLocationManager();
        CLLocationCoordinate2D pin = new CLLocationCoordinate2D();
        Universal functions;
        List<Pin> pinList;

        public HomePageViewController(IntPtr handle) : base(handle)
        {
        }
        /// <summary>
        /// Sends a request to gather all the pins from the database
        /// </summary>
        private async void GetPinList()
        {
            pinList = await functions.getPins("");

            if (pinList != null)
            {
                foreach (Pin newPin in pinList)
                {
                    AddAnnotation(newPin.title, newPin.desc, newPin.latitude, newPin.longitude);
                }

            }
        }
        /// <summary>
        /// Creates a pin on the map
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public void AddAnnotation(string title, string desc, string latitude, string longitude)
        {

            mapView.AddAnnotations(new MKPointAnnotation()
            {
                Title = title,
                Subtitle = desc,
                Coordinate = new CLLocationCoordinate2D(Convert.ToDouble(latitude), Convert.ToDouble(longitude))
            });
        }
        /// <summary>
        /// Clears all the pins from the maps, to avoid duplicates
        /// </summary>
        private void ClearAnnotations()
        {
            IMKAnnotation[] anonList = mapView.Annotations;
            foreach (IMKAnnotation anon in anonList)
            {
                mapView.RemoveAnnotation(anon);
            }
        }
        /// <summary>
        /// Gesture method that recongnizes long pressing on map, creates a pin
        /// </summary>
        /// <param name="recognizer"></param>
        private void MapLongPress(UILongPressGestureRecognizer recognizer)
        {
            if (recognizer.State != UIGestureRecognizerState.Began) return;

            var map = mapView as MKMapView;

            if (map == null) return;

            var pixelLocation = recognizer.LocationInView(map);
            pin = map.ConvertPoint(pixelLocation, map);

            PerformSegue("PinnedCreationSegue", this);
            ClearAnnotations();
            GetPinList();

        }
        /// <summary>
        /// Preps the next view controller before we change views
        /// </summary>
        /// <param name="segue"></param>
        /// <param name="sender"></param>
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var transferdata = segue.DestinationViewController as PinPopupViewController;
            if (transferdata != null)
            {
                transferdata.longi = pin.Longitude.ToString();
                transferdata.lat = pin.Latitude.ToString();
				transferdata.homepage = this;
            }
        }
        /// <summary>
        /// After view controller loads this function builds the map
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            functions = new Universal();
            Title = "User Location";


            mapView = new MKMapView(View.Bounds);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            mapView.AddGestureRecognizer(new UILongPressGestureRecognizer(MapLongPress));
            View.AddSubview(mapView);



            //Request permission to access device location
            locationManager.RequestAlwaysAuthorization();


            // this is required to show the blue dot indicating user-location
            mapView.ShowsUserLocation = true;

            Console.WriteLine("initial loc:" + mapView.UserLocation.Coordinate.Latitude + "," + mapView.UserLocation.Coordinate.Longitude);


            mapView.DidUpdateUserLocation += (sender, e) =>
            {
                if (mapView.UserLocation != null)
                {
                    Console.WriteLine("userloc:" + mapView.UserLocation.Coordinate.Latitude + "," + mapView.UserLocation.Coordinate.Longitude);
                    CLLocationCoordinate2D coords = mapView.UserLocation.Coordinate;
                    MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(2), MilesToLongitudeDegrees(2, coords.Latitude));
                    mapView.Region = new MKCoordinateRegion(coords, span);

                }
            };


            if (!mapView.UserLocationVisible)
            {
                // user denied permission, or device doesn't have GPS/location ability
                Console.WriteLine("userloc not visible, show cupertino");
                CLLocationCoordinate2D coords = new CLLocationCoordinate2D(37.33233141, -122.0312186); // cupertino
                MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(20), MilesToLongitudeDegrees(20, coords.Latitude));
                mapView.Region = new MKCoordinateRegion(coords, span);
            }


            int typesWidth = 260, typesHeight = 30, distanceFromBottom = 60;
            mapTypes = new UISegmentedControl(new CGRect((View.Bounds.Width - typesWidth) / 2, View.Bounds.Height - distanceFromBottom, typesWidth, typesHeight));
            mapTypes.InsertSegment("Road", 0, false);
            mapTypes.InsertSegment("Satellite", 1, false);
            mapTypes.InsertSegment("Hybrid", 2, false);
            mapTypes.SelectedSegment = 0; // Road is the default
            mapTypes.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
            mapTypes.ValueChanged += (s, e) =>
            {
                switch (mapTypes.SelectedSegment)
                {
                    case 0:
                        mapView.MapType = MKMapType.Standard;
                        break;
                    case 1:
                        mapView.MapType = MKMapType.Satellite;
                        break;
                    case 2:
                        mapView.MapType = MKMapType.Hybrid;
                        break;
                }
            };

            View.AddSubview(mapTypes);

            ClearAnnotations();
            GetPinList();



        }


        //Converts miles to latitude degrees

        public double MilesToLatitudeDegrees(double miles)
        {
            double earthRadius = 3960.0;
            double radiansToDegrees = 180.0 / Math.PI;
            return (miles / earthRadius) * radiansToDegrees;
        }

        /// <summary>
        /// Converts miles to longitudinal degrees at a specified latitude
        /// </summary>
        public double MilesToLongitudeDegrees(double miles, double atLatitude)
        {
            double earthRadius = 3960.0;
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;

            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (miles / radiusAtLatitude) * radiansToDegrees;
        }


        protected class BasicMapAnnotation : MKAnnotation
        {
            /// <summary>
            /// The location of the annotation
            /// </summary>
            CLLocationCoordinate2D coord;
            string title, subtitle;

            public override CLLocationCoordinate2D Coordinate
            {
                get { return coord; }
            }
            public override void SetCoordinate(CLLocationCoordinate2D value)
            {
                coord = value;
            }


            public override string Title
            {
                get { return title; }
            }

            /// <summary>
            /// The subtitle text
            /// </summary>
            public override string Subtitle
            {
                get { return subtitle; }
            }

            public BasicMapAnnotation(CLLocationCoordinate2D coordinate, string title, string subTitle)
                    : base()
            {
                coord = coordinate;
                this.title = title;
                this.subtitle = subTitle;
            }
        }
    }
}
