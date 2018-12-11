using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.BL
{
    public class Authenticator : IAuthenticator
    {
        private readonly ILoginDal _loginDal;

        public Authenticator(ILoginDal loginDal)
        {
            this._loginDal = loginDal;
        }
       
        public Employee Login(int Id, string password)
        {
            return _loginDal.Login(Id, password);
        }

      
    }
}
