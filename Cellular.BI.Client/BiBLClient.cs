using Cellular.Common.BI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using models = Cellular.Common.Models;

namespace Cellular.BI.Client
{
    public class BiBLClient
    {
        private const string urlServerBase = "http://localhost:50602/";

        public List<MostValue> MostProfitableClients()
        {
            using (var httpClient =new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetMostProfitableClients").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<MostValue>>(jsonResult);
                }
                return null;
            }
        }

        public MostCallingToCenter[] MostCallingToServiceCenter()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetMostCallingToServiceCenter").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<MostCallingToCenter[]>(jsonResult);
                }
                return null;
            }
        }

        public models.Client[] PotentialFriendsGroups()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetPotentialFriendsGroups").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<models.Client[]>(jsonResult);
                }
                return null;
            }
        }

        public BestSeller[] BestSellers()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetBestSellers").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<BestSeller[]>(jsonResult);
                }
                return null;
            }
        }
    }
}
