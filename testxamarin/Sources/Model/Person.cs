using System;
using SQLite;

namespace testxamarin
{
	[Table("tb_person")]
	public class Person : IObject
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set;}
		[Ignore]
		public Uri Avatar { get;  set; }
		[MaxLength(20)]
		public String Name { get;  set;}
		public int Age { get;  set;}
		[MaxLength(500)]
		public String Location { get;  set; }

		public Person() {
			
		}

		public Person(String avatar, String name, int age, String location)
		{
			Avatar = new Uri(avatar);
			Name = name;
			Age = age;
			Location = location;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

