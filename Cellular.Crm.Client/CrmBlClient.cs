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

        public Mods.Client SaveClientDetails(int id, string password, string firstName, string lastName, int registeredBy, ClientTypeEnum clientTypeId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                var clientEdited = new Mods.Client()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    RegisteredBy = registeredBy,
                    ClientTypeId = clientTypeId

                };
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

        public void AddNewClient(int id, string lastName, string firstName, string password, int employeeId, ClientTypeEnum clientTypeId)
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
                    RegisteredBy = employeeId,
                    ClientTypeId = clientTypeId

                };
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PostAsJsonAsync("api/Clients/AddClient", client).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Couldn't post this object");
            }

        }

        public void AddNewLinePlusPackage(Line line, Package package)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (line == null)
                    return;
                var response = httpClient.PostAsJsonAsync("api/Lines/AddNewLine", line).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (package == null)
                        return;
                    var responsePack = httpClient.PostAsJsonAsync("api/Lines/AddNewPackage", package).Result;
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

        public Package SavePackageChanges(Package packageEdited)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.PutAsJsonAsync("api/Lines/EditPackage", packageEdited).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Package>(jsonResult);
                }
                return null;
            }
        }

        public Mods.Client GetClientDetails(int clientId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(urlServerBase);
                var response = httpClient.GetAsync($"api/Clients/GetClientDetails?clientId={clientId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Client>(jsonResult);

                }
            }
            return null;
        }
    }

}

