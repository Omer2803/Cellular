using Cellular.Common.Invoices.Models;
using Cellular.Invoices.Client.HttpClients;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly LoginHttpClient httpClient = new LoginHttpClient();

        private int? id;
        public int? Id
        {
            get => id;
            set
            {
                id = value;
                Notify();
                Notify(nameof(CanTryLogin));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                Notify();
                Notify(nameof(CanTryLogin));
            }
        }

        public bool CanTryLogin
        {
            get
            {
                return
                    id.HasValue
                    && !string.IsNullOrEmpty(password)
                    && !isTryingLogin;
            }
        }

        private bool isTryingLogin = false;

        public async Task TryLogin()
        {
            if (CanTryLogin)
            {
                isTryingLogin = true;
                TryingLogin?.Invoke();
                var result = await httpClient.TryLogin(Id.Value, Password);

                if (result != null
                    && (result.ResultType == LoginResultEnum.Client
                    || result.ResultType == LoginResultEnum.Employee))
                {
                    Logedin?.Invoke(result.Result);
                }
                else
                {
                    isTryingLogin = false;
                    LoginFailed?.Invoke();
                }
            }
        }

        public event Action<object> Logedin;
        public event Action LoginFailed;
        public event Action TryingLogin;

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
