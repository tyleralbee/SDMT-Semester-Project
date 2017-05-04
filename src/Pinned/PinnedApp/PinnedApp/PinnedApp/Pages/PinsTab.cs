using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using Xamarin.Forms.GoogleMaps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace PinnedApp
{
	public class PinsTab : ContentPage
	{
		APIController apiController;
		UserCreationDTO dto;
		private double lat;
		private double longititude;
		public bool visible = true;
		public PinsTab(double latit, double longts)
		{
			lat = latit;
			longititude = longts;
			apiController = new APIController(); //Creates APIController, This might need to move to TestPage.cs

			Title = "PinsTab";
			IsVisible = visible;
			Content = BuildChildren();
		}

		private View BuildChildren()
		{
			var map = new Map()
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HasZoomEnabled = true,
				IsVisible = true
			};
			Debug.WriteLine("{0} {1}", lat, longititude);
			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position((double)lat, (double)longititude), Distance.FromMiles(1)));
			Debug.WriteLine("{0} {1}", lat, longititude);
			return new StackLayout
			{

				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Children = {
					map
				}
			};
		}

	}
}

