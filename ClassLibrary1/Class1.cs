using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClassLibrary1
{
    public class Class1
    {
        public List<Client> GetAllClients()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:50602/");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync("api/Clients/GetAllClients").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                   // return JsonConvert.DeserializeObject<List<Cellular.Common.Models.Client>>(jsonResult);
                }
            }
            return null;
        }
    }
}
