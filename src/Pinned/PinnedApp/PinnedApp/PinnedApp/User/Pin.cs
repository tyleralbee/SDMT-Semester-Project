using System;
namespace PinnedApp
{
	public class Pin
	{
        public string idPins;
        public string userID;
        public string title;
        public string desc;
        public string longitude;
        public string latitude;
        public string timestamp;

        public Pin(string idPins, string userID, string title, string desc, string longitude, string latitude, string timestamp)
        {
            this.idPins = idPins;
            this.userID = userID;
            this.title = title;
            this.desc = desc;
            this.longitude = longitude;
            this.latitude = latitude;
            this.timestamp = timestamp;
        }
    }
}
