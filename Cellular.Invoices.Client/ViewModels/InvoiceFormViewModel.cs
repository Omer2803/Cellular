using Cellular.Common.Invoices.Models;
using Cellular.Invoices.Client.HttpClients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.ViewModels
{
    public class InvoiceFormViewModel : INotifyPropertyChanged
    {
        private readonly InvoiceFormHttpClient httpClient = new InvoiceFormHttpClient();

        private int clientId;
        public int ClientId
        {
            get => clientId;
            set => SetClientId(value);
        }
        private async void SetClientId(int value)
        {
            clientId = value;
            Numbers = await httpClient.NumbersOf(value);
        }

        public List<string> SelectedNumbers { get; set; }

        public DateTimeOffset From { get; set; }

        public DateTimeOffset Until { get; set; }

        public int Month { get; set; }

        private bool isEmployee;
        public bool IsEmployee
        {
            get => isEmployee;
            set
            {
                isEmployee = value;
                Notify();
            }
        }

        private string[] numbers;
        public string[] Numbers
        {
            get => numbers;
            set
            {
                numbers = value;
                Notify();
            }
        }

        public async Task GetInvoice()
        {
            var invoice = await httpClient.GetInvoice(ClientId, From.Date, Until.Date);
            GotInvoice?.Invoke(invoice);
        }

        public event Action<Invoice> GotInvoice;

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
