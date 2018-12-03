using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml;

namespace Cellular.CRM.Client
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public void Login(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {

                var response = httpClient.GetAsync("http://localhost:50602/api/Clients/LoginEmployee?id=5&password=4").Result;
                if (response.IsSuccessStatusCode)
                {
                   
                }
            }
        }
    }
}
