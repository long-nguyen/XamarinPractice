
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace testxamarin
{
	/// <summary>
	/// Đây là file hỗ trợ truy cập Database, sử dụng thư viện SQLite.Net,
	/// Bước 1: Cài đặt package sqlite.net bằng NuGet, chú ý là cài đặt cho cả 3 nền tảng là Xaml, Droid và iOS bằng cách click chuôt phải vào mục package, chọn add Package
	/// Bước 2: Tạo file Database helper, trong đó SQLConnection được tạo bằng Dependency Injection, vì sao, vì file database được lưu ở các vị trí khác nhau trong từng platform, nên là 
	/// ta phải viết code riêng ở từng platform. Chỉ định xem ở đó sẽ đặt cái gì.
	/// </summary>
    public class DatabaseHelper 
    {
		protected static object locker = new object ();

		protected SQLiteConnection database; 

		public DatabaseHelper()
        {
			//Lấy database instance theo từng platform 
            database = DependencyService.Get<IDatabase>().DBConnect();
        }

		public void doTest() {
			//Tạo bảng nếu cần
			database.CreateTable<Person>();
			//database.Execute("create table tb_person(id int primary key not null);");
			//Gen sample data
			var person = new Person("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-1.jpg", "Steve", 21, "USA");
			var per2 = new Person("http://www.gruener-baum-wuerzburg.de/images/avatar/avt-2.jpg", "John", 37, "USA");
			database.Insert(person);
			database.Insert(per2);

			List<Person> result = (List<Person>)GetItems();
			Log.d("DOne, count : " + result.Count);
		}
			
		public IEnumerable<Person> GetItems ()
        {
            lock (locker) {
				return (from i in database.Table<Person>() select i).ToList();
            }
        }

		//public IEnumerable<Item> GetFirstItems ()
  //      {
  //          lock (locker) {
  //              return database.Query<Item>("SELECT * FROM Item WHERE Name = 'First'");
  //          }
  //      }

		//public Item GetItem(int id) 
  //      {
  //          lock (locker) {
  //              return database.Table<Item>().FirstOrDefault(x => x.ID == id);
  //          }
  //      }

		//public int SaveItem(Item item) 
  //      {
  //          lock (locker) {
  //              if (item.ID != 0) {
  //                  database.Update(item);
  //                  return item.ID;
  //              } else {
  //                  return database.Insert(item);
  //              }
  //          }
  //      }

		//public int DeleteItem(int id)
  //      {
  //          lock (locker) {
  //              return database.Delete<Item>(id);
  //          }
  //      }

		//public void DeleteAllItems()
		//{
		//	lock (locker) {
		//		database.DropTable<Item>();
		//		database.CreateTable<Item>();
		//	}
		//}
    }

}
