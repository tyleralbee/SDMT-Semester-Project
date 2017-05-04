using System;
namespace PinnedApp
{
    /// <summary>
    /// Holds user data after sucessfull login
    /// </summary>
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
