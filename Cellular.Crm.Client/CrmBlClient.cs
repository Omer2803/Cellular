using Cellular.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cellular.CRM.Client
{
    public class CrmBlClient
    {
        private const string urlServerBase = "http://localhost:50602/";

        public Employee LoginEmployee(int id, string password)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var response = httpClient.GetAsync($"api/Clients/LoginEmployee?id={id}&password={password}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Employee>(jsonResult);

                }
            }
            return null;
        }

        public List<Common.Models.Client> GetAllClients()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var response = httpClient.GetAsync($"api/Clients/GetAllClients").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Cellular.Common.Models.Client>>(jsonResult);

                }
            }
            return null;
        }



        public void AddNewClient(int id, string lastName, string firstName, string password, int employeeId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var newClient = new Cellular.Common.Models.Client()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    RegisterationDate = DateTime.Now,
                    RegisteredBy = employeeId
                };
                var response = httpClient.PostAsJsonAsync($"api/Clients/AddClient", newClient).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Couldn't post this object");
            }

        }
    }

}

