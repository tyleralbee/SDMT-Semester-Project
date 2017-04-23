using System;
using Amazon.APIGateway;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
namespace Pinned
{
	public class UserCreationTab : ContentPage
	{
		APIController apiController;
		UserCreationDTO dto;
		Entry txtUserName;
		Entry txtPassword;
		Entry txtEmail;
		Entry txtFirstname;
		Entry txtLastname;
		Button btnCreateUser;
		Entry txtConfirmation;
		Button btnConfirmUser;
		private bool succesfulCreation = false;

		public UserCreationTab()
		{
			apiController = new APIController(); //Creates APIController, This might need to move to TestPage.cs

			Title = "User Creation";
			Content = BuildChildren();
		}

		private View BuildChildren()
		{

			txtUserName = entryUserName();
			txtPassword = entryPassword();
			txtEmail = entryEmail();
			txtFirstname = entrFirstName();
			txtLastname = entryLastName();
			btnCreateUser = buttonCreateUser();
			txtConfirmation = entryConfirmation();
			btnConfirmUser = buttonConfirmUser();


			return new StackLayout
			{
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Children = {
					txtUserName,
					txtPassword,
					txtEmail,
					txtFirstname,
					txtLastname,
					btnCreateUser,
					txtConfirmation,
					btnConfirmUser
				}
			};
		}

		private Entry entryUserName()
		{
			return new Entry
			{
				Placeholder = "Enter username to create"
			};
		}
		private Entry entryPassword()
		{
			return new Entry
			{
				Placeholder = "Enter password for useraccount"
			};
		}
		private Entry entryEmail()
		{
			return new Entry
			{
				Placeholder = "Enter email"
			};
		}
		private Entry entrFirstName()
		{
			return new Entry
			{
				Placeholder = "Enter first name"
			};
		}
		private Entry entryLastName()
		{
			return new Entry
			{
				Placeholder = "Enter last name"
			};
		}
		private Entry entryConfirmation()
		{
			return new Entry
			{
				Placeholder = "Enter confirmation code",
				IsVisible = succesfulCreation
			};
		}
		private async void ConfirmUserAPI(object sender, EventArgs e)
		{
			dto = new UserCreationDTO(txtUserName.Text, txtPassword.Text, txtEmail.Text, txtFirstname.Text, txtLastname.Text, txtConfirmation.Text);
			var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserComfirmation, dto);

			if (json.Contains("{}"))
			{
				await DisplayAlert("", "Sucess", "");
			}
		}
		private Button buttonConfirmUser()
		{
			Button btn = new Button
			{
				Text = "Confirm",
				IsVisible = succesfulCreation

			};


			btn.Clicked += ConfirmUserAPI;


			return btn;
		}


		private async void CreateUserAPI(object sender, EventArgs e)
		{
			dto = new UserCreationDTO(txtUserName.Text, txtPassword.Text, txtEmail.Text, txtFirstname.Text, txtLastname.Text, null);
			var json = await apiController.ExecuteAPI(APIEnum.apiEnum.UserCreation, dto);

			if (json.Contains("CodeDeliveryDetails"))
			{
				succesfulCreation = true;
				btnConfirmUser.IsVisible = true;
				txtConfirmation.IsVisible = true;
				Debug.WriteLine("Awaiting confirmation");
			}

			await DisplayAlert("Alert", json, "OK");
		}

		private Button buttonCreateUser()
		{
			Button btn = new Button
			{
				Text = "Create account",

			};


			btn.Clicked += CreateUserAPI;


			return btn;
		}
	}
}

