using System;

using Xamarin.Forms;

namespace Pinned
{
	public class TestPage : TabbedPage
	{
		public TestPage()
		{
			Children.Add(new UserCreationTab());
		}
	}
}

