using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;


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

        public async void createUser(string username, string password, string email, string firstName, string lastName)
        {
            dto = new UserCreationDTO(username, password, email, firstName, lastName, null);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserCreation, dto);

            if (json.Contains("CodeDeliveryDetails"))
            {
                Debug.WriteLine("Awaiting confirmation");
            }

        }

        public async void confirmUser(string username, string password, string email, string firstName, string lastName, string confirmationCode)
        {
            dto = new UserCreationDTO(username, password, email, firstName, lastName, confirmationCode);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserComfirmation, dto);

            if (json.Contains("{}"))
            {
                Debug.WriteLine("Userconfirmed");
            }
        }

    }
}
