using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PinnedApp
{
    public class Universal
    {
        APIController apiController;
        UserCreationDTO dto;
        public UserSession user;

        public Universal()
        {
            apiController = new APIController(); //Creates APIController, This might need to move to TestPage.cs
        }
        /// <summary>
        /// sends request to log user in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> loginUser(string username, string password)
        {
            bool sucess = false;
            dto = new UserCreationDTO(username, password, null, null, null, null);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserLogin, dto);

            if (json.Contains("RefreshToken"))
            {
                user = JsonConvert.DeserializeObject<UserSession>(json);
                Debug.WriteLine("Access token: {0}", user.AccessToken);
                sucess = true;
            }

            return sucess;
        }
        /// <summary>
        /// Sends a sql request to create a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public async void createUser(string username, string password, string email, string firstName, string lastName)
        {
            dto = new UserCreationDTO(username, password, email, firstName, lastName, null);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserCreation, dto);

            if (json.Contains("CodeDeliveryDetails"))
            {
                Debug.WriteLine("Awaiting confirmation");
            }

        }
        /// <summary>
        /// After user is created, confirmation code is sent to email, this send this confirmation code to finalze account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="confirmationCode"></param>
        public async void confirmUser(string username, string password, string email, string firstName, string lastName, string confirmationCode)
        {
            dto = new UserCreationDTO(username, password, email, firstName, lastName, confirmationCode);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserComfirmation, dto);

            if (json.Contains("{}"))
            {
                Debug.WriteLine("Userconfirmed");
            }
        }
        /// <summary>
        /// Gets all the pins related to user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<Pin>> getPins(string username)
        {
            dto = new UserCreationDTO(null, null, null, null, null, null);

            dto.memberID = "1";
            List<Pin> pins = null;
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.GetPins, dto);

            if (json.Contains("userID"))
            {
               pins = JsonConvert.DeserializeObject<List<Pin>>(json);
            }

            return pins;
        }
        /// <summary>
        /// Creates a new pin on the map
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="longitiude"></param>
        /// <param name="latitude"></param>
        public async void createPin(string title, string desc, string longitiude, string latitude)
        {
            dto = new UserCreationDTO(null, null, null, null, null, null);

            dto.memberID = "1";
            dto.title = title;
            dto.description = desc;
            dto.longitude = longitiude;
            dto.latitude = latitude;

            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.CreatePin, dto);

            if (json.Contains("affectedRows"))
            {
                Debug.WriteLine("Userconfirmed");
            }
        }

    }
}
