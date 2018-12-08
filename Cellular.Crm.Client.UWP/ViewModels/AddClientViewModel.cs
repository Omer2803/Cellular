using Cellular.Common.Models;
using Cellular.CRM.Client.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client.UWP.ViewModels
{
    public class AddClientViewModel : INotifyPropertyChanged
    {
        private readonly Page page;
        private CrmBlClient _crmBlClient;


        public int EmployeeId { get; set; }

        public Employee Registrator { get; set; }


        private ClientTypeEnum _clientTypeId;

        public ClientTypeEnum ClientTypeId
        {
            get { return _clientTypeId; }
            set { _clientTypeId = value; Notify(nameof(ClientTypeId)); }
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; Notify(nameof(Id)); }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; Notify(nameof(FirstName)); }
        }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; Notify(nameof(LastName)); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; Notify(nameof(Password)); }
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; Notify(nameof(Error)); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public AddClientViewModel(Page page)
        {
            this.page = page;
            _crmBlClient = new CrmBlClient();
        }

        public void AddNewClient(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientTypeId = (ClientTypeEnum)((Button)sender).CommandParameter;
                _crmBlClient.AddNewClient(Id, LastName, FirstName, Password, EmployeeId, ClientTypeId);
                page.Frame.Navigate(typeof(ClientsView), EmployeeId);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void NavigateToClientsView(object sender, RoutedEventArgs e)
        {
            page.Frame.Navigate(typeof(ClientsView));
        }
    }
}
