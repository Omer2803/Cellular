using Cellular.CRM.Client.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client.UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Page _page;
        private CrmBlClient _crmBlClient;

        public LoginViewModel(Page page)
        {
            this._page = page;
            _crmBlClient = new CrmBlClient();
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; Notify(nameof(Id)); }
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

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Login employee according to his password and ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                var loginEmployee = _crmBlClient.LoginEmployee(Id, Password);
                if (loginEmployee != null)
                {
                    _page.Frame.Navigate(typeof(ClientsView), Id);
                }
                else
                {
                    Error = "The username or the password isn't correct";
                }

            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            
        }
    }
}
