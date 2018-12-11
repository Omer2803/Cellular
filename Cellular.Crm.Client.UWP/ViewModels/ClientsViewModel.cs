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
        private bool isEditLine;
        private bool isAddLine;
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
                Clients = new ObservableCollection<Common.Models.Client>(listCliens);
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

        private int _employeeId;

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; Notify(nameof(EmployeeId)); }
        }
        public Cellular.Common.Models.Client ClientSelected { get; set; }

        public void NavigateToAddClientView(object sender, RoutedEventArgs e)
        {
            _page.Frame.Navigate(typeof(AddClientView), EmployeeId);
        }

        public void NavigateToEditClientView(object sender, RoutedEventArgs e)
        {
            if (ClientSelected != null)
            {
                _page.Frame.Navigate(typeof(EditClientView), ClientSelected.Id);
            }
        }

        public void NavigateToAddLineView(object sender, RoutedEventArgs e)
        {
            if (ClientSelected != null)
            {
                isEditLine = false;
                isAddLine = !isEditLine;
                _page.Frame.Navigate(typeof(LineView),Tuple.Create(ClientSelected.Id, isEditLine,isAddLine));

            }

        }

        public void NavigateToEditLineView(object sender, RoutedEventArgs e)
        {
            if (ClientSelected != null)
            {
                isEditLine = true;
                isAddLine = !isEditLine;
                _page.Frame.Navigate(typeof(LineView), Tuple.Create(ClientSelected.Id,isEditLine, isAddLine));

            }
        }
    }
}
