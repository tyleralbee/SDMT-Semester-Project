using System;
namespace PinnedApp
{
	public class createPin : Payload
	{
        public string memberID;
        public string title;
        public string desc;
        public string longitude;
        public string latitude;

		public createPin(UserCreationDTO dto)
		{
            memberID = dto.memberID;
            title = dto.title;
            desc = dto.description;
            longitude = dto.longitude;
            latitude = dto.latitude;
        }
	}
}
