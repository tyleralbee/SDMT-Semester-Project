using System;
namespace PinnedApp
{
	public class userConfirm : Payload
	{
		public string ClientId;
		public string Username;
		public string ConfirmationCode;
		public userConfirm(UserCreationDTO dto)
		{
			ClientId = "15n8eopq46ul2re3ppho7jf1f1"; //so bad need to make a constant file
			Username = dto.getTxtUsername();
			ConfirmationCode = dto.getTxtConfirmation();   
		}
	}
}
