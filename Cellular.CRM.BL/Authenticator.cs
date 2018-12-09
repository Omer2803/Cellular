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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Employee Login(int Id, string password)
        {
            return _loginDal.Login(Id, password);
        }

        public void Logout(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
