using Cellular.Common.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.BL.Invoices
{
    public class Authenticator : IAuthenticator
    {
        private readonly IDALAuthenticator dALAuthenticator;

        public Authenticator(IDALAuthenticator dALAuthenticator)
        {
            this.dALAuthenticator = dALAuthenticator;
        }

        public object Login(int id, string password)
        {
            return dALAuthenticator.GetClientOrEmployee(id, password);
        }
    }
}
