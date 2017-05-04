using System;
using System.Diagnostics;
namespace PinnedApp
{
    /// <summary>
    /// Event portion of json
    /// </summary>
	public class Event
	{
		public string operation;
		public Payload payload;

		public Event(APIEnum.apiEnum api, DTO dto)
		{
			operation = getOperation(api);
			payload = getPayload(api, dto);
		}

		private Payload getPayload(APIEnum.apiEnum api, DTO dto)
		{
			switch (api)
			{
				case APIEnum.apiEnum.UserCreation:
					return new userSignup((UserCreationDTO)dto);
				case APIEnum.apiEnum.UserComfirmation:
					return new userConfirm((UserCreationDTO)dto);
				case APIEnum.apiEnum.UserLogin:
					return new userLogin((UserCreationDTO)dto);
                case APIEnum.apiEnum.GetPins:
                    return new getPins((UserCreationDTO)dto);
                case APIEnum.apiEnum.CreatePin:
                    return new createPin((UserCreationDTO)dto);
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
				case APIEnum.apiEnum.UserLogin:
					return "userLogin";
                case APIEnum.apiEnum.GetPins:
                        return "getPins";
                case APIEnum.apiEnum.CreatePin:
                        return "createPin";
                default:
					Debug.WriteLine("There was an issue");
					return "Error";
			};
		}
	}
}
