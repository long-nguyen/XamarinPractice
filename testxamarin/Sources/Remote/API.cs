using System;
using System.Collections;
using Flurl;
using Flurl.Http;
namespace testxamarin
{
	/// <summary>
	/// Để cài đặt và sử dụng được thư viện Flurl này, ta cần cài bằng NUGET (mở Project/Add Nuget package rồi search)
	/// Hướng dẫn: 
	/// http://tmenier.github.io/Flurl/error-handling/
	/// Delegate
	/// 
	/// Thằng FlUrl này tự parse json thành object luôn, hoặc có thể query string về, tuỳ yêu cầu
	/// </summary>

	public class Error {
		public String Message { get; set;}
		public int Status { get; set;}
	}

	public delegate void SuccessCallback(Object o);
	public delegate void ErrorCallback(Error e);

	public class API
	{
		public static void sampleRequest(Object param, SuccessCallback scb, ErrorCallback ecb)
		{
			Url url = APIDef.SERVER_BASE
					.AppendPathSegment(APIDef.API_ABC)
					.SetQueryParams(param);
			requestJson(url, scb, ecb);
		}

		/// <summary>
		/// Template API
		/// </summary>
		/// <returns>The API.</returns>
		/// <param name="param">Parameter.</param>
		/// <param name="scb">Scb.</param>
		/// <param name="ecb">Ecb.</param>
		public async static void requestJson(Url url, SuccessCallback scb, ErrorCallback ecb) {
			try {
				Object result = await url.GetJsonAsync();
				//TODO: Check data if error 
				if (scb != null) {
					scb(result);	
				}
				Log.d("c:" + DateTime.Now.Millisecond);
			} catch (FlurlHttpTimeoutException) {
				//Timeout
				if (ecb != null)
				{
					ecb(new Error()
					{
						Message = "Timeout"
					});
				}
			} catch (FlurlHttpException e) {
				//Fail with Exception
				if (ecb != null) {
					if (e.Call.Response != null)
					{
						ecb(new Error()
						{
							Message = e.Call.Response.ReasonPhrase,
						});
					}
					else {
						ecb(new Error()
						{
							Message = e.Message
						});
					}	
				}
			}
		}


		/// <summary>
		/// Template API
		/// </summary>
		/// <returns>The API.</returns>
		/// <param name="param">Parameter.</param>
		/// <param name="scb">Scb.</param>
		/// <param name="ecb">Ecb.</param>
		public async static void requestOther(Url url, SuccessCallback scb, ErrorCallback ecb)
		{
			try
			{
				Object result = await url.GetAsync();
				//TODO: Check data if error 
				if (scb != null)
				{
					scb(result);
				}
				Log.d("c:" + DateTime.Now.Millisecond);
			}
			catch (FlurlHttpTimeoutException)
			{
				//Timeout
				if (ecb != null)
				{
					ecb(new Error()
					{
						Message = "Timeout"
					});
				}
			}
			catch (FlurlHttpException e)
			{
				//Fail with Exception
				if (ecb != null)
				{
					if (e.Call.Response != null)
					{
						ecb(new Error()
						{
							Message = e.Call.Response.ReasonPhrase,
						});
					}
					else {
						ecb(new Error()
						{
							Message = e.Message
						});
					}
				}
			}
		}
	}
}

