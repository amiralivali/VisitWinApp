using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Visit.UI
{
    internal class HttpClientHelper
    {
        HttpClient httpClient;
        public HttpClientHelper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(RouteConstants.BaseUrl);
        }
        public async Task<T> GetAsync<T>(string route)
        {
            var response = await httpClient.GetAsync(route);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
        public async Task<Tout> PostAsync<Tout, Tin>(string route,Tin data)
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "Application/json"); 
            var response = await httpClient.PostAsync(route,stringContent);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Tout>(content);
            return result;
        }
    }
}
