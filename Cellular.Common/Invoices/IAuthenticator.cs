namespace Cellular.Common.Invoices
{
    public interface IAuthenticator
    {
        object Login(int id, string password);
    }
}
