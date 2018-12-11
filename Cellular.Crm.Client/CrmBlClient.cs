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
        private const string URLSERVERBASE = "http://localhost:50602/";

        public Mods.Employee LoginEmployee(int id, string password)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
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
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
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
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
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
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
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
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
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
                    throw new Exception("Can't add this client");
            }

        }

        public void AddNewPackage(bool includesMiutes, bool includesSms, bool includesFriends, int maxMinutes, int maxSms, string number1, string number2, string number3, string phoneNumber, double totalPrice)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Package package = new Package()
                {
                    IncludesFriends = includesFriends,
                    IncludesMinuets = includesMiutes,
                    IncludesSMSes = includesSms,
                    LineNumber = phoneNumber,
                    MaxMinuets = maxMinutes,
                    MaxSMSes = maxSms,
                    Number1 = number1,
                    Number2 = number2,
                    Number3 = number3,
                    TotalPrice = totalPrice

                };
                var response = httpClient.PostAsJsonAsync("api/Lines/AddNewPackage", package).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Can't add this package");

            }
        }

        public void AddNewLine(string phoneNumber, int clientId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Line line = new Line()
                {
                    ClientId = clientId,
                    PhoneNumber = phoneNumber
                };
                var response = httpClient.PostAsJsonAsync("api/Lines/AddNewLine", line).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Can't add this line");
            }
        }

        public Package GetPackageOfLine(string lineNumber)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                var response = httpClient.GetAsync($"api/Lines/GetPackageOfLine?lineNumber={lineNumber}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Package>(jsonResult);

                }
            }
            return null;
        }

        public Mods.Client GetClientDetails(int clientId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                var response = httpClient.GetAsync($"api/Clients/GetClientDetails?clientId={clientId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Mods.Client>(jsonResult);

                }
            }
            return null;
        }

        public void UpdatePackageChanges(int packageId, bool includesMiutes, bool includesSms, bool includesFriends, int maxMinutes, int maxSms, string number1, string number2, string number3, string phoneNumber, double totalPrice)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URLSERVERBASE);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Package packageEdited = new Package()
                {
                     Id = packageId,
                    IncludesFriends = includesFriends,
                    IncludesMinuets = includesMiutes,
                    IncludesSMSes = includesSms,
                    LineNumber = phoneNumber,
                    MaxMinuets = maxMinutes,
                    MaxSMSes = maxSms,
                    Number1 = number1,
                    Number2 = number2,
                    Number3 = number3,
                    TotalPrice = totalPrice

                };
                var response = httpClient.PutAsJsonAsync("api/Lines/EditPackage", packageEdited).Result;
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Can't add this package");

            }
        }
    }

}

