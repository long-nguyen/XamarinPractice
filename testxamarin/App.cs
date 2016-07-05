using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace testxamarin
{
	public class App : Application
	{
		static DatabaseHelper db;              //  basic respository (database class only)

		public static DatabaseHelper DB{
			get
			{
				if (db == null)
				{
					db = new DatabaseHelper();
				}
				return db;
			}
		}

		//Bước 1, tạo root object
		public App()
		{
			//Set root page là drawer
			MainPage = new NavigationDrawer();
		}

		protected override void OnStart()
		{
			Debug.WriteLine("OnStart");
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			Debug.WriteLine("OnSleep");

		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

