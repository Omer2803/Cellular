using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IAuthenticator
    {
        /// <summary>
        /// Login employee
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Employee Login(int Id, string password);
    }
}
