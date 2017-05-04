using System;
namespace PinnedApp
{
	public class userLogin : Payload
	{
		public string ClientId;
		public string AuthFlow;
		public AuthParameters AuthParameters;
		public string UserPoolId;

		public userLogin(UserCreationDTO dto)
		{
			ClientId = "15n8eopq46ul2re3ppho7jf1f1";
			AuthFlow = "ADMIN_NO_SRP_AUTH";
			AuthParameters = new AuthParameters(dto.getTxtUsername(), dto.getTxtPassword());
			UserPoolId = "us-west-2_aIe0eGFfZ";
		}
	}
}
