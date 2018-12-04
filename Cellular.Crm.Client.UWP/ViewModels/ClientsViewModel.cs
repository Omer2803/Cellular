using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellular.Common.Models;
using Cellular.CRM.Client.UWP.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client.UWP.ViewModels
{
    public class ClientsViewModel : INotifyPropertyChanged
    {
        private Page _page;
        private CrmBlClient _crmBlClient;


        public ClientsViewModel(Page page)
        {
            _page = page;
            _crmBlClient = new CrmBlClient();
            GetAllClients();
        }

        private void GetAllClients()
        {
            var listCliens = _crmBlClient.GetAllClients();
            if (listCliens != null)
            {
                Clients = new ObservableCollection<Common.Models.Client>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private ObservableCollection<Cellular.Common.Models.Client> _clients;

        public ObservableCollection<Cellular.Common.Models.Client> Clients
        {
            get { return _clients; }
            set { _clients = value; Notify(nameof(Clients)); }
        }

        public void NavigateToAddClientView(object sender, RoutedEventArgs e)
        {
            _page.Frame.Navigate(typeof(AddClientView),id);

        }




    }
}
