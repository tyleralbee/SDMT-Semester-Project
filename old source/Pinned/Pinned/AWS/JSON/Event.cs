using System;
using System.Diagnostics;
namespace Pinned
{
	public class Event
	{
		public string operation;
		public Payload payload;

		public Event(APIEnum.apiEnum api, DTO dto)
		{
			operation = getOperation(api);
			payload = getPayload(api, dto);
			Debug.WriteLine("{0}", payload);
		}

		private Payload getPayload(APIEnum.apiEnum api, DTO dto)
		{
			switch (api)
			{
				case APIEnum.apiEnum.UserCreation:
					return new userSignup((UserCreationDTO)dto);
				case APIEnum.apiEnum.UserComfirmation:
					return new userConfirm((UserCreationDTO)dto);
				default:
					Debug.WriteLine("There was an issue");
					return null;
			};
		}

		private string getOperation(APIEnum.apiEnum api)
		{
			switch (api)
			{
				case APIEnum.apiEnum.UserCreation:
					Debug.WriteLine("Operation is UserCreation");
					return "userSignup";
				case APIEnum.apiEnum.UserComfirmation:
					return "userConfirm";
				default:
					Debug.WriteLine("There was an issue");
					return "Error";
			};
		}
	}
}
