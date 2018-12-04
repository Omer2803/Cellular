using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cellular.CRM.Client
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Page _page;
        public LoginViewModel(Page page)
        {
            this._page = page;
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

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Login(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:50602/");
                var response =  httpClient.GetAsync("api/Clients/LoginEmployee?id=5&password=4").Result;
                if (response.IsSuccessStatusCode)
                {
                    
                }
            }
        }
    }
}
