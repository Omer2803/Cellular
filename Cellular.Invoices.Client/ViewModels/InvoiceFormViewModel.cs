using Cellular.Common.Invoices.Models;
using Cellular.Invoices.Client.HttpClients;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.ViewModels
{
    public class InvoiceFormViewModel : INotifyPropertyChanged
    {
        private readonly InvoiceFormHttpClient httpClient = new InvoiceFormHttpClient();

        private int? clientId;
        public int? ClientId
        {
            get => clientId;
            set
            {
                clientId = value;
                Notify(nameof(ClientId));
                Notify(nameof(CanGetInvoice));
            }
        }

        private int? year;
        public int? Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
                Notify(nameof(CanGetInvoice));
            }
        }
        private int? month;
        public int? Month
        {
            get => month;
            set
            {
                month = value;
                Notify(nameof(CanGetInvoice));
            }
        }

        public bool IsEmployee { get; set; }

        public bool CanGetInvoice
        {
            get
            {
                return
                    clientId.HasValue
                    && year.HasValue
                    && month.HasValue;
            }
        }

        public int[] Months { get; } = Enumerable.Range(1, 12).ToArray();

        public async Task GetInvoice()
        {
            if (!CanGetInvoice) return;
            var invoice = await httpClient.GetInvoice(clientId.Value, year.Value, month.Value);
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
