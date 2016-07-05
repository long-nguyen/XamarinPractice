using System;
using Xamarin.Forms;

namespace testxamarin
{
	public class Utils
	{
		private Utils(){
		}

		/// <summary>
		/// Only to save primitive type
		/// </summary>
		public static void savePref(String key, String value) {
			key = Const.PKG_NAME + "_" + key;
			Application.Current.Properties[key] = value;
		}

		public static String loadPref(String key) {
			key = Const.PKG_NAME + "_" + key;
			var data = Application.Current.Properties[key];
			if (data != null) {
				return (String)data;
			}
			return null;
		}
	}
}

