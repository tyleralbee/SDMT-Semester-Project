using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
namespace PinnedApp
{
	public class LoginPage : ContentPage
	{
		APIController apiController;
		UserCreationDTO dto;
		Entry txtUserName;
		Entry txtPassword;
		Button btnConfirmUser;
		UserSession user;
		public LoginPage()
		{
			apiController = new APIController(); //Creates APIController, This might need to move to TestPage.cs

			Title = "User Login";
			Content = BuildChildren();
		}

		private View BuildChildren()
		{

			txtUserName = entryUserName();
			txtPassword = entryPassword();
			btnConfirmUser = buttonLoginUser();


			return new StackLayout
			{
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Children = {
					txtUserName,
					txtPassword,
					btnConfirmUser
				}
			};
		}

		private Entry entryUserName()
		{
			return new Entry
			{
				Placeholder = "Enter username"
			};
		}
		private Entry entryPassword()
		{
			return new Entry
			{
				Placeholder = "Enter password"
			};
		}
		private async void loginUserApi(object sender, EventArgs e)
		{
			dto = new UserCreationDTO(txtUserName.Text, txtPassword.Text, null, null, null, null);
			var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserLogin, dto);

			if (json.Contains("RefreshToken"))
			{
				user = JsonConvert.DeserializeObject<UserSession>(json);
				Debug.WriteLine("Access token: {0}", user.AccessToken);

			}

			await DisplayAlert("Alert", json, "OK");
		}

        public async void loginUserApi(string username, string password)
        {
            dto = new UserCreationDTO(username, password, null, null, null, null);
            var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserLogin, dto);

            if (json.Contains("RefreshToken"))
            {
                user = JsonConvert.DeserializeObject<UserSession>(json);
                Debug.WriteLine("Access token: {0}", user.AccessToken);

            }

            await DisplayAlert("Alert", json, "OK");
        }


        private Button buttonLoginUser()
		{
			Button btn = new Button
			{
				Text = "login",

			};


			btn.Clicked += loginUserApi;


			return btn;
		}
	}
}

