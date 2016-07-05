using System;

namespace testxamarin
{
	/// <summary>
	/// Interface dành riêng cho object database, object nào cũng cần ID hết 
	/// </summary>
	public interface IObject 
	{
		int ID { get; set; }
	}

}

