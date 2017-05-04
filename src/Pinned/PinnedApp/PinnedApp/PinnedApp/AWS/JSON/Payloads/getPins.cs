using System;
namespace PinnedApp
{
	public class getPins : Payload
	{
        public string memberID;
		public getPins(UserCreationDTO dto)
		{
            memberID = dto.memberID;
        }
	}
}
