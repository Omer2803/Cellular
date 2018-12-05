using Cellular.Common.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cellular.Simulator.Client.HttpClients
{
    public class SimulatorHttpClient
    {
        const string baseAddres = "http://localhost:50602/";
        private readonly Uri uri = new Uri(baseAddres);

        public async Task<string[]> NumbersOf(int clientId)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.GetAsync($"api/simulator/numbersof?clientid={clientId}");

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<string[]>();

                return null;
            }
        }

        public async Task PostCall(Call call)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.PostAsJsonAsync($"api/simulator/addcall", call);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Could not post the call");
            }
        }

        public async Task PostSMS(SMS sms)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.PostAsJsonAsync($"api/simulator/addsms. ", sms);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Could not post the SMS. ");
            }
        }
    }
}
