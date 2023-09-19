using AssetManagementAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AssetManagementConsole
{
    public class ApiCall<T> : IApiCall<T> where T : class
    {
        private readonly string endPoint;
        private readonly HttpClient client;

        public ApiCall(string ep)
        {
            endPoint = ep;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7176/");
        }
        public IQueryable<T> GetData()
        {
            var response = client.GetAsync(endPoint).Result;
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine("No Data Available");
                return null;
            }
            else if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent).AsQueryable();
                return getResponse;
            }
            else
            {
                return null;
            }
        }

        public int PostData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(endPoint, content).Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine(responseContent);
                return -1;
            }

            else
            {

                if (int.TryParse(responseContent, out int res))
                {
                    return res;
                }
                return 0;
            }
        }

        public int PatchData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PatchAsync(endPoint, content).Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;

            if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine(responseContent);
                return -1;
            }

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine(responseContent);
                return -1;
            }

            return 0;
        }
    }
}
