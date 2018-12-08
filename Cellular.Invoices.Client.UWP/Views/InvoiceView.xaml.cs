using Cellular.Common.Invoices.Models;
using Cellular.Invoices.Client.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Cellular.Invoices.Client.UWP.Views
{
    public sealed partial class InvoiceView : Page
    {
        public InvoiceViewModel ViewModel { get; set; }

        public InvoiceView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = e.Parameter as Invoice;
        }

        private void Back_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
    }
}
