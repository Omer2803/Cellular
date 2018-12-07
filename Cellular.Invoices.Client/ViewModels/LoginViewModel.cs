using Cellular.Common.Invoices.Models;
using Cellular.Invoices.Client.HttpClients;
using System;
using System.Threading.Tasks;

namespace Cellular.Invoices.Client.ViewModels
{
    public class LoginViewModel
    {
        private readonly LoginHttpClient httpClient = new LoginHttpClient();

        public string Password { get; set; }

        public int Id { get; set; }

        private bool canTryLogin = true;

        public async Task TryLogin()
        {
            if (canTryLogin)
            {
                canTryLogin = false;
                TringLogin?.Invoke();
                var result = await httpClient.TryLogin(Id, Password);
                if (result.ResultType == LoginResultEnum.Client
                   || result.ResultType == LoginResultEnum.Employee)
                    Logedin?.Invoke(result.Result);
                else
                {
                    canTryLogin = true;
                    LoginFailed?.Invoke();
                }
            }
        }

        public event Action<object> Logedin;
        public event Action LoginFailed;
        public event Action TringLogin;
    }
}
