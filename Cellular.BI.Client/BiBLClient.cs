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
        private const string URLSERVERBASE = "http://localhost:50602/";

        public List<MostValue> MostProfitableClients(int count)
        {
            using (var httpClient =new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetMostProfitableClients?count=" + count).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<MostValue>>(jsonResult);
                }
                return null;
            }
        }

        public MostCallingToCenter[] MostCallingToServiceCenter(int count)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetMostCallingToServiceCenter?count=" + count).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<MostCallingToCenter[]>(jsonResult);
                }
                return null;
            }
        }
        
        public BestSeller[] BestSellers(int count)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/BI/GetBestSellers?count=" + count).Result;
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
