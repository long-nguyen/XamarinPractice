using System;
using System.IO;
using testxamarin;
using testxamarin.Droid;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(Database_Android))]
namespace testxamarin.Droid
{
	/// <summary>
	/// Cấu hình database path cho android, chú ý tên file
	/// </summary>
    public class Database_Android : IDatabase
    {
        public Database_Android() { }
        public SQLiteConnection DBConnect()
        {
			var filename = DatabaseDef.DBName;
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }

}