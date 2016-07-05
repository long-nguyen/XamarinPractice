using System;
using System.Diagnostics;

namespace testxamarin
{
	public class Log
	{
		private Log(){
		}

		public static void d(String msg) {
			Debug.WriteLine(msg);
		}

	}
}

