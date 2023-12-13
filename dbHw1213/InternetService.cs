using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dbHw1213
{
	internal class InternetService
	{
		HttpClient client = new HttpClient();
		private string url = "https://retoolapi.dev/W0DlKu/data";
		public List<DataDef> GetAll()
{
			string json = client.GetStringAsync(url).Result;
			return JsonConvert.DeserializeObject<List<DataDef>>(json);
		}

		public DataDef Add(DataDef input)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
			HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
			Debug.WriteLine(responseMessage.ToString());
			Debug.WriteLine(null);
			Debug.WriteLine(responseMessage.Content);
			return null;
		}
		public DataDef Modify(DataDef input)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
			HttpResponseMessage responseMessage = client.PatchAsync(url, content).Result;
			Debug.WriteLine(responseMessage.ToString());
			Debug.WriteLine(null);
			Debug.WriteLine(responseMessage.Content);
			Console.WriteLine(responseMessage.ToString());
			Console.WriteLine(responseMessage.Content);
			return null;
		}

		internal bool Delete(DataDef user)
		{
			int id = user.id;
			HttpResponseMessage response = client.DeleteAsync($"{url}/{id}").Result;
			return response.IsSuccessStatusCode;
		}
	}
}
