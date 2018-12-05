using Mods = Cellular.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.Client
{
    public class CrmBlClient
    {
        private const string urlServerBase = "http://localhost:50602/";

        public Mods.Employee LoginEmployee(int id, string password)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var response = httpClient.GetAsync($"api/Clients/LoginEmployee?id={id}&password={password}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Employee>(jsonResult);

                }
            }
            return null;
        }

        public List<Mods.Client> GetAllClients()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:50602/api/Clients/GetAllClients");
                string js = httpRequest.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Cellular.Common.Models.Client>>(js);
                //var response = httpClient.GetAsync($"api/Clients/GetAllClients").Result;
                //string jsonResult = response.Content.ReadAsStringAsync().Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    return JsonConvert.DeserializeObject<List<Cellular.Common.Models.Client>>(jsonResult);

                //}
            }
            //return null;
        }



        public void AddNewClient(int id, string lastName, string firstName, string password, int employeeId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var client = new Common.Models.Client()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    RegisterationDate = DateTime.Now,
                    RegisteredBy = employeeId
                };
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
                //var json = JsonConvert.SerializeObject(client);
                var response = httpClient.PostAsJsonAsync("api/Clients/AddClient", client).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Couldn't post this object");
            }

        }
    }

}

