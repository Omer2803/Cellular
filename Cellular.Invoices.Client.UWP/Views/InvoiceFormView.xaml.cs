using Models = Cellular.Common.Models;
using Cellular.Invoices.Client.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Cellular.Invoices.Client.UWP.Views
{
    public sealed partial class InvoiceFormView : Page
    {
        public InvoiceFormViewModel ViewModel { get; set; }

        public InvoiceFormView()
        {
            ViewModel = new InvoiceFormViewModel();
            ViewModel.GotInvoice += invoice => { Frame.Navigate(typeof(InvoiceView), invoice); };

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.IsEmployee = e.Parameter is Models.Employee;
            if (e.Parameter is Models.Client c)
                ViewModel.ClientId = c.Id;
        }
    }
}
