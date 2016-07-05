using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace testxamarin
{
	public partial class SecondPage : ContentPage
	{
		String bundle;
		public SecondPage(String data)
		{
			this.bundle = data;
			InitializeComponent();
			setData();
		}

		private void setData()
		{
			//Khi chúng ta set x:name trong file thì tự nó coi như là tên biến ở file cs rồi 
			usernameLbl.Text = bundle;

			//Customize toolbar
			ToolbarItems.Clear();
			ToolbarItems.Add(new ToolbarItem
			{
				Text = " Home",
				Order = ToolbarItemOrder.Secondary,
				Command = new Command(() => Navigation.PopAsync())
			});
			//Modal pop
			ToolbarItems.Add(new ToolbarItem
			{
				Text = " Page List",
				Order = ToolbarItemOrder.Secondary,
				//Command = new Command(() => Navigation.PushModalAsync(new ListPage()))
				Command = new Command(() => Navigation.PushAsync(new ListPage()))
			});



		}
		/// <summary>
		/// Ons the oval clicked. Sự kiện này gọi từ button ở file xaml
		/// </summary>
		/// <returns>The oval clicked.</returns>
		/// <param name="o">O.</param>
		/// <param name="a">The alpha component.</param>
		async void OnOvalClicked(Object o, EventArgs a) {
			await DisplayActionSheet("Options", "Cancel", null, "Here", "There");
		}
	}
}

