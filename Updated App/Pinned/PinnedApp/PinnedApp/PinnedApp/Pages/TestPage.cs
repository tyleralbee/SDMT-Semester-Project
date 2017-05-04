using System;
using System.Diagnostics;
using Plugin.Geolocator;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace PinnedApp
{
	public class TestPage : TabbedPage
	{
		private double lat;
		private double longititude;

		private async Task GetLocation()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100;
			var position = await locator.GetPositionAsync(timeoutMilliseconds: 5000);
			lat = position.Latitude;
			longititude = position.Longitude;
			Debug.WriteLine("{0} {1}", lat, longititude);
			return;
		}
		private async void Location()
		{
			await GetLocation();
			return;
		}

		public TestPage()
		{
			Location();
			Children.Add(new PinsTab(lat, longititude));
			Children.Add(new UserCreationTab());
			Children.Add(new LoginPage());
		}
	}
}

