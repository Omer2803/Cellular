using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IAuthenticator
    {
        Employee Login(string username, string password);

        void Logout(int employeeId);
    }
}
