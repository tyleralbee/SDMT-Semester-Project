using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;


namespace PinnedApp
{
    public class Universal
    {
        APIController apiController;
        UserCreationDTO dto;
        UserSession user;

        public async void loginUser(string username, string password)
        {
            dto = new UserCreationDTO(username, password, null, null, null, null);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserLogin, dto);

            if (json.Contains("RefreshToken"))
            {
                user = JsonConvert.DeserializeObject<UserSession>(json);
                Debug.WriteLine("Access token: {0}", user.AccessToken);

            }
        }


    }
}
