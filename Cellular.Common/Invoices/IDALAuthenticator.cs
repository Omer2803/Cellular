using Cellular.Common.Invoices.Models;

namespace Cellular.Common.Invoices
{
    public interface IDALAuthenticator
    {
        LoginResult GetClientOrEmployee(int id, string password);
    }
}
