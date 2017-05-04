using System;
using Xamarin.Forms;
namespace PinnedApp
{
	public class UserCreationDTO : DTO
	{


		private string txtUserName;
		public string getTxtUsername()
		{
			return txtUserName;
		}
		private string txtPassword;
		public string getTxtPassword()
		{
			return txtPassword;
		}
		private string txtEmail;
		public string getTxtEmail()
		{
			return txtEmail;
		}
		private string txtFirstname;
		public string getTxtFirstname()
		{
			return txtFirstname;
		}
		private string txtLastname;
		public string getTxtLastname()
		{
			return txtLastname;
		}
		private string txtConfirmation;
		public string getTxtConfirmation()
		{
			return txtConfirmation;
		}


		public UserCreationDTO(string _txtUserName, string _txtPassword, string _txtEmail, string _txtFirstname, string _txtLastname, string _txtConfirm)
		{
			txtUserName = _txtUserName;
			txtPassword = _txtPassword;
			txtEmail = _txtEmail;
			txtFirstname = _txtFirstname;
			txtLastname = _txtLastname;
			txtConfirmation = _txtConfirm;
		}


	}
}
