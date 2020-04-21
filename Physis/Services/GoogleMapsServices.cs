using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Physis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Physis.Services
{
    public class GoogleMapsServices
    {
        public async Task<double> GetLatitude(string url, Address address)
        {
            double latitude;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                JObject jsonDataObject = JsonConvert.DeserializeObject<JObject>(jsonData);
                latitude = Double.Parse(jsonDataObject["results"][0]["geometry"]["location"]["lat"].ToString());
                return latitude;
            }
            return 0;
        }

        public async Task<double> GetLongitude(string url, Address address)
        {
            double longitude;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                JObject jsonDataObject = JsonConvert.DeserializeObject<JObject>(jsonData);
                longitude = Double.Parse(jsonDataObject["results"][0]["geometry"]["location"]["lon"].ToString());
                return longitude;
            }
            return 0;
        }
    }
}
