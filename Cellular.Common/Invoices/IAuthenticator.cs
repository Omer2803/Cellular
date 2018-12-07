using Cellular.Common.Invoices.Models;

namespace Cellular.Common.Invoices
{
    public interface IAuthenticator
    {
        LoginResult Login(int id, string password);
    }
}
