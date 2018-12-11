using Cellular.Invoices.Client.ViewModels;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Cellular.Invoices.Client.UWP.Views
{
    public sealed partial class LoginView : Page
    {
        public LoginViewModel ViewModel { get; set; }

        public LoginView()
        {
            ViewModel = new LoginViewModel();
            ViewModel.Logedin += clientOrEmployee => Frame.Navigate(typeof(InvoiceFormView), clientOrEmployee);
            ViewModel.LoginFailed += () =>
            {
                messagetbl.Text = "ID or password is incorrect";
                messagetbl.Foreground = new SolidColorBrush(Colors.Red);
            };
            ViewModel.TryingLogin += () =>
            {
                messagetbl.Foreground = new SolidColorBrush(Colors.Black);
                messagetbl.Text = "Please wait...";
            };

            this.InitializeComponent();
        }
    }
}
