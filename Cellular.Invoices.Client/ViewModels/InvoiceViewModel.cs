using Cellular.Invoices.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.ViewModels
{
    public class InvoiceViewModel
    {
        private readonly InvoiceHttpClient httpClient = new InvoiceHttpClient();

        public int ClientId { get; set; }

        public List<string> SelectedNumbers { get; set; }

        public DateTime From { get; set; }

        public DateTime Until { get; set; }

        public int Month { get; set; }

        public bool IsEmployee { get; set; }

        private string[] numbers;
        public string[] Numbers
        {
            get { return numbers; }
            set { numbers = value; }
        }

        public List<string> SelecedNumbers { get; set; }

        public async Task GetInvoice()
        {

        }

        public event Action GorInvoice;
    }
}
