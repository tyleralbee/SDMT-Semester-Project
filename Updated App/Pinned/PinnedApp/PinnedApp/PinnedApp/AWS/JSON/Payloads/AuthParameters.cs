using System;
using Newtonsoft.Json;
namespace PinnedApp
{
	public class AuthParameters
	{
		[JsonProperty("USERNAME")]
		private string Username;
		[JsonProperty("PASSWORD")]
		private string Password;

		public AuthParameters(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
