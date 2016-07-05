using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace testxamarin
{
	public partial class ListPage : ContentPage
	{
		private List<Person> people;

		public ListPage()
		{
			InitializeComponent();
			initView();
		}

		private void initView() {
			people = new List<Person>{
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Steve", 21, "USA"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg", "John", 37, "USA"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Tom", 42, "UK"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Lucas", 29, "Germany"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg","Tariq", 39, "UK"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg","Jane", 30, "USA"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Lan", 21, "USA"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg", "Hung", 37, "USA"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Quan", 42, "UK"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg","Lucas", 29, "Germany"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg","Thang", 39, "UK"),
				new Person ("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg","Van", 30, "USA")
			};

			personList.ItemsSource = people;

			personList.ItemSelected += (sender, e) =>
			{

				if (e.SelectedItem == null) {
					//Unselect the item
					return;
				}
				((ListView)sender).SelectedItem = null;
				//Show alert
				DisplayAlert("Item selected", e.SelectedItem.ToString(), "OK");
			};

			//Listview pull to refresh
			personList.IsPullToRefreshEnabled = true;
		}

		void onItemButtonClick(object sender, System.EventArgs e)
		{
			var b = (Button)sender;
			var item = (Person)b.CommandParameter;
			DisplayAlert("Button on item clicked", item.Name, "OK");
		}
	}
}

