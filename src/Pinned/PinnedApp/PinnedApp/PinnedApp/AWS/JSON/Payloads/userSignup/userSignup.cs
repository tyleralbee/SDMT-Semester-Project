using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;


namespace PinnedApp
{
	public class userSignup : Payload
	{
		public string ClientId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		[JsonProperty(Order = 4)]
		public List<UserAttribute> UserAttributes ;

		public userSignup(UserCreationDTO dto)
		{
			UserAttributes = new List<UserAttribute>();
			Debug.WriteLine("{0} {1} {2} {3} {4}", dto.getTxtUsername(), dto.getTxtPassword(), dto.getTxtEmail(), dto.getTxtFirstname(), dto.getTxtLastname());
			ClientId = "15n8eopq46ul2re3ppho7jf1f1";
			Username = dto.getTxtUsername();
			Password = dto.getTxtPassword();
			UserAttributes.Add(new UserAttribute("given_name", dto.getTxtFirstname()));
			UserAttributes.Add(new UserAttribute("family_name", dto.getTxtLastname()));
			UserAttributes.Add(new UserAttribute("email", dto.getTxtEmail()));

			Debug.WriteLine("User: {0} Pass: {1}", Username, Password);
		}


	}
}
