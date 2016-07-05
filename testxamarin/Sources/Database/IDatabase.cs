using System;
using SQLite;

namespace testxamarin
{
	/// <summary>
	/// Interface này sẽ được implement ở từng platform
	/// </summary>
    public interface IDatabase
    {
        SQLiteConnection DBConnect();
    }

}
