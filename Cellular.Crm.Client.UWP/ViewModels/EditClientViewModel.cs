using Cellular.Common.Models;
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
        private readonly string _successMessage = "The changes were saved!";
        private readonly string _failMessage = "Can't changes these properties";


        #region ClientProperties
        public Cellular.Common.Models.Client clientEdited { get; set; }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; Notify(nameof(Id)); GetClientDetails(Id); }
        }

        private int _registeredBy;
        public int RegisteredBy
        {
            get { return _registeredBy; }
            set { _registeredBy = value; Notify(nameof(RegisteredBy)); }
        }

        private Employee _registrator;
        public Employee Registrator
        {
            get { return _registrator; }
            set { _registrator = value; Notify(nameof(Registrator)); }
        }

        private ClientTypeEnum _clientTypeId;
        public ClientTypeEnum ClientTypeId
        {
            get { return _clientTypeId; }
            set { _clientTypeId = value; }
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
        /// <summary>
        /// Get Client details by Id
        /// </summary>
        /// <param name="id"></param>
        private void GetClientDetails(int id)
        {
            clientEdited = _crmBlClient.GetClientDetails(id);
            FirstName = clientEdited.FirstName;
            LastName = clientEdited.LastName;
            Password = clientEdited.Password;
            RegisteredBy = clientEdited.RegisteredBy;
            ClientTypeId = clientEdited.ClientTypeId;
        }
        #endregion
        /// <summary>
        /// Save changes details of client
        /// </summary>
        /// <param name="page"></param>
        public EditClientViewModel(Page page)
        {
            this._page = page;
            _crmBlClient = new CrmBlClient();
        }

        public void SaveDetails(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientTypeId = (ClientTypeEnum)((Button)sender).CommandParameter;
                var succesEdited = _crmBlClient.SaveClientDetails(Id, Password, FirstName, LastName, RegisteredBy, ClientTypeId);
                if (succesEdited != null)
                {
                    InitSuccussMessage(_successMessage);
                }
                else
                {
                    Error = _failMessage;
                }

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async void InitSuccussMessage(string msg)
        {
            MessageDialog messageDialog = new MessageDialog(msg);
            await messageDialog.ShowAsync();
            _page.Frame.Navigate(typeof(ClientsView), RegisteredBy);
        }

        public void NavigateToClientsView(object sender, RoutedEventArgs e)
        {
            _page.Frame.Navigate(typeof(ClientsView));
        }
    }
}
