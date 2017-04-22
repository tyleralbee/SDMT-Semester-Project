using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinned
{
	public partial class AdminPage : ContentPage
	{
		public AdminPage()
		{
			InitializeComponent();
			Content = createAdminPage();
		}

		private View createAdminPage()
		{
			var header = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Helo World!"
			};

			return new StackLayout
			{
				Padding = 3,
				Children = {
	  				header
				}
			};
		}
	}
}
