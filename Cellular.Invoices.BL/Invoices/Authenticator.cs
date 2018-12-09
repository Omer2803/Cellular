using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;

namespace Cellular.Invoices.BL.Invoices
{
    public class Authenticator : IAuthenticator
    {
        private readonly IDALAuthenticator dALAuthenticator;

        public Authenticator(IDALAuthenticator dALAuthenticator)
        {
            this.dALAuthenticator = dALAuthenticator;
        }

        public LoginResult Login(int id, string password)
        {
            return dALAuthenticator.GetClientOrEmployee(id, password);
        }
    }
}
