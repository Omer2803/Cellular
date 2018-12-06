using Cellular.CRM.Client.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client.UWP.ViewModels
{
    public class EditClientViewModel : INotifyPropertyChanged
    {
        private readonly Page _page;
        private CrmBlClient _crmBlClient;
        public Cellular.Common.Models.Client clientEdited { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public EditClientViewModel(Page page)
        {
            this._page = page;
            _crmBlClient = new CrmBlClient();
        }

        public void SaveDetails(object sender, RoutedEventArgs e)
        {
           var succesEdited = _crmBlClient.SaveClientDetails(clientEdited);
            if (succesEdited != null)
            {
                InitSuccussMessage();
            }
        }

        private async void InitSuccussMessage()
        {
            MessageDialog messageDialog = new MessageDialog("The client updated successfully");
            await messageDialog.ShowAsync();
            _page.Frame.Navigate(typeof(ClientsView));
        }
    }
}
