using System;
using Xamarin.Forms;

namespace testxamarin
{
	public class NavigationDrawer : MasterDetailPage
	{
		/// <summary>
		/// Đây là file cài đặt cho Navigation Drawer
		/// </summary>
		public NavigationDrawer()
		{
			Title = "Navigation Drawer Using MasterDetailPage";
			string[] myPageNames = { "Home", "Second", "Third" };
			ListView listView = new ListView
			{
				ItemsSource = myPageNames,
			};
			this.Master = new ContentPage
			{
				Title = "Options",
				Content = listView,
				Icon = "hamburger.png"
			};

			listView.ItemTapped += (sender, e) =>{
				ContentPage gotoPage;
				switch (e.Item.ToString())
				{
					case "Home":
						gotoPage = new HomePage();
						break;
					case "Second":
						gotoPage = new SecondPage("a");
						break;
					case "Third":
						gotoPage = new ListPage();
						break;
					default:
						gotoPage = new HomePage();
						break;
				}
				Detail = new NavigationPage(gotoPage)
				{
					BarBackgroundColor = Color.FromHex("#45c3f3"),
					BarTextColor = Color.White
				};
				((ListView)sender).SelectedItem = null;
				this.IsPresented = false;
			};
			Detail = new NavigationPage(new HomePage())
			{
				BarBackgroundColor = Color.FromHex("#45c3f3"),
				BarTextColor = Color.White
			};


		}
	}
}

