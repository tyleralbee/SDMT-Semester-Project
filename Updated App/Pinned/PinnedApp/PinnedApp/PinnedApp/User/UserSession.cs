using System;
namespace PinnedApp
{
	public class UserSession
	{

		public string AccessToken;
		public int ExpiresIn;
		public string TokenType;
		public string RefreshToken;
		public string IdToken;
		public UserSession(string accessToken, int expiresIn, string tokenType, string refreshToken, string idToken)
		{
			AccessToken = accessToken;
			ExpiresIn = expiresIn;
			TokenType = tokenType;
			RefreshToken = refreshToken;
			IdToken = idToken;
		}
	}
}
