using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinned
{
	public partial class MyPage : ContentPage
	{
		public MyPage()
		{
			InitializeComponent();
			Content = new Label
			{
				Text = "Hello, Forms !",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
		}
	}
}
