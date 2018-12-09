using Cellular.Common.Invoices.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Models = Cellular.Common.Models;

namespace Cellular.Invoices.Client.HttpClients
{
    class LoginHttpClient
    {
        private const string baseAdress = "http://localhost:50602/";
        private readonly Uri uri = new Uri(baseAdress);

        public async Task<LoginResult> TryLogin(int id, string password)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.PostAsJsonAsync($"api/invoices/Login", new LoginModel { Id = id, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoginResult>();
                    switch (result.ResultType)
                    {
                        case LoginResultEnum.Client:                            
                                result.Result = JsonConvert.DeserializeObject<Models.Client>(JsonConvert.SerializeObject(result.Result));
                            break;
                        case LoginResultEnum.Employee:
                            result.Result = JsonConvert.DeserializeObject<Models.Employee>(JsonConvert.SerializeObject(result.Result));
                            break;
                        default:
                            break;
                    }
                    return result;
                }
                return null;
            }
        }
    }
}
