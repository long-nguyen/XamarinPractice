using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Flurl;
using Flurl.Http;

namespace testxamarin
{
	/// <summary>
	/// Trang chính, chứa các component ví dụ và layout chính là stacklayotu  
	/// </summary>
	public class HomePage : ContentPage
	{
		Label topLabel;
		Button firstButton, secondButton;
		Entry entry;
		Image myImage;
		StackLayout contentLayout;

		public HomePage()
		{
			initView();
			Log.d("a:" + DateTime.Now.Millisecond);
			testLoadData();
			Log.d("b:" + DateTime.Now.Millisecond);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		private void initView() {
			topLabel = new Label()
			{
				Text = "Test label",
				HorizontalOptions = LayoutOptions.Center
			};
			firstButton = new Button()
			{
				Text = "Go to next page",
			};
			firstButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SecondPage("abc"));
			};
			secondButton = new Button()
			{
				Text = "Go to the list page",
			};
			secondButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new ListPage());
			};
			entry = new Entry()
			{
				Placeholder = "Input me"
			};

			myImage = new Image()
			{
				Source = ImageSource.FromUri(new Uri("http://imaging.nikon.com/lineup/lens/zoom/normalzoom/af-s_dx_18-140mmf_35-56g_ed_vr/img/sample/sample1_l.jpg")),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.FillAndExpand

			};
			Picker picker = new Picker()
			{
				Title = "Option"
			};
			var options = new List<String>
			{
				"First", "Second", "Third", "Last"
			};
			foreach (string optionname in options)
			{
				picker.Items.Add(optionname);
			}


			contentLayout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10),
				Children = {
					topLabel,
					firstButton,
					secondButton,
					picker,
					entry,
					myImage
				}
			};
			this.Content = contentLayout;
		}

		private  void testLoadData() {
			App.DB.doTest();

		}
	}
}


