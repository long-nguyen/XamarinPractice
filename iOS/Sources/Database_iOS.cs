using System;
using SQLite;
using System.IO;
using Xamarin.Forms;
using testxamarin.iOS;

[assembly: Dependency(typeof(Database_iOS))]
namespace testxamarin.iOS
{
	/// <summary>
	/// Cài đặt DB path cho ios, chú ý là đối với ios thì buộc phải đặt trong thư mục library
	/// </summary>
	public class Database_iOS : IDatabase
	{
		public Database_iOS() { }
		public SQLiteConnection DBConnect()
		{
			var filename = DatabaseDef.DBName;
			string folder = 
				Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryFolder = Path.Combine (folder, "..", "Library"); 
			var path = Path.Combine(libraryFolder, filename);
			var connection = new SQLiteConnection(path);
			return connection;
		}
	}
}


