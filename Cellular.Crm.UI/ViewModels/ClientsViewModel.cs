using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Crm.UI.ViewModels
{
    public class ClientsViewModel
    {
        internal void GetClients()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:50602/");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync("api/Clients/GetAllClients").Result;
                if (response.IsSuccessStatusCode)
                {
                    //string jsonResult = response.Content.ReadAsStringAsync().Result;
                    //return JsonConvert.DeserializeObject<List<Client>(jsonResult);
                }
            }
        }
    }
}
