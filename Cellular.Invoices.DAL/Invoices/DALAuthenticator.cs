using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using Cellular.MainDal;

namespace Cellular.Invoices.DAL.Invoices
{
    public class DALAuthenticator : IDALAuthenticator
    {
        public LoginResult GetClientOrEmployee(int id, string password)
        {
            using (var context = new CellularDbContext())
            {
                LoginResultEnum resultType = 0;
                object result = null;

                var client = context.Clients.Find(id);

                if (client != null)
                {
                    if (client.Password == password)
                    {
                        resultType = LoginResultEnum.Client;
                        result = client;
                    }
                    else resultType = LoginResultEnum.WrongPassword;
                }
                else
                {
                    var employee = context.Employees.Find(id);
                    if (employee != null)
                    {
                        if (employee.Password == password)
                        {
                            resultType = LoginResultEnum.Employee;
                            result = employee;
                        }
                        else resultType = LoginResultEnum.WrongPassword;
                    }
                }
                return new LoginResult { ResultType = resultType, Result = result };
            }
        }
    }
}
