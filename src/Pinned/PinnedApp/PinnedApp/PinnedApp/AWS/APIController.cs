using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace PinnedApp
{
	public class APIController
	{
        /// <summary>
        /// Sends a http request to our api
        /// </summary>
        /// <param name="evn"></param>
        /// <returns></returns>
		async Task<string> GetAPIAsync(Event evn)
		{
			HttpClient client;

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

			var uri = new Uri(string.Format("https://eq3fvn8ejh.execute-api.us-west-2.amazonaws.com/prod/userservices"));

			var json = JsonConvert.SerializeObject(evn);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.PostAsync(uri, content);

			Debug.WriteLine("{0}", json.ToString());

			var responseString = await response.Content.ReadAsStringAsync();

			return responseString;
		}


        /// <summary>
        /// helper method for api request
        /// </summary>
        /// <param name="api"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
		public async Task<string> ExecuteAPI(APIEnum.apiEnum api, DTO dto)
		{
			Event newEvent = new Event(api, dto);


			String result = await GetAPIAsync(newEvent);
			Debug.WriteLine("{0}", result);
			return result;
		}

	}
}
