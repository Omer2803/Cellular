using Cellular.Common.Invoices.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.HttpClients
{
    class InvoiceHttpClient
    {
        private const string baseAdress= "";
        private readonly Uri uri = new Uri(baseAdress);

        public async Task<string[]> NumbersOf(int clientId)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.GetAsync($"api/simulator/numbersof/{clientId}");

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<string[]>();

                return null;
            }
        }

        public async Task<Invoice> GetInvoice(int clientId, DateTime from, DateTime until)
        {
            using (var client = new HttpClient { BaseAddress = uri })
            {
                var response = await client.PostAsJsonAsync($"api/invoices/get",
                    new GetInvoiceModel { ClientId = clientId, From = from, Until = until });

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsAsync<Invoice>();

                return null;
            }
        }
    }
}
