using Mods = Cellular.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cellular.Common.Models;

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

        public List<Mods.Line> GetLinesByClientId(int clientId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.GetAsync("api/Lines/GetLinesByClientId?clientId=" + clientId).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Mods.Line>>(jsonResult);
                }
                return null;
            }
        }

        public Mods.Client SaveClientDetails(Mods.Client clientEdited)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var response = httpClient.PutAsJsonAsync("api/Clients/EditClient", clientEdited).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Cellular.Common.Models.Client>(jsonResult);
                }
                return null;
            }
        }

        public List<Mods.Client> GetAllClients()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync("api/Clients/GetAllClients").Result;
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
                var response = httpClient.PostAsJsonAsync("api/Clients/AddClient", client).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Couldn't post this object");
            }

        }

        public void AddNewLine(string phoneNumber, int clientId, Package package)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var line = new Common.Models.Line()
                {
                    PhoneNumber = phoneNumber,
                    ClientId = clientId
                };
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsJsonAsync("api/Lines/AddLine", line).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responsePack = httpClient.PostAsJsonAsync("api/Lines/AddPackage", package).Result;
                    if (!responsePack.IsSuccessStatusCode)
                        throw new Exception("Couldn't post this object");
                }
                else
                {

                    throw new Exception("Couldn't post this object");
                }
            }
        }

        public Package GetPackageOfLine(string lineNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var response = httpClient.GetAsync($"api/Lines/GetPackageOfLine?lineNumber={lineNumber}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Package>(jsonResult);

                }
            }
            return null;
        }
    }

}

