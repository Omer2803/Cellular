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

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; Notify(nameof(Id)); }
        }

        private int _employeeId;
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; Notify(nameof(EmployeeId)); }
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

        public void AddNewClient(object sender, RoutedEventArgs routedEvent)
        {
            try
            {
                _crmBlClient.AddNewClient(Id, LastName, FirstName, Password, EmployeeId);

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}
