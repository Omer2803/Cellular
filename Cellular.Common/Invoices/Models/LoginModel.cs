namespace Cellular.Common.Invoices.Models
{
    /// <summary>
    /// Serves as a DTO to be sent form a client side to a server,
    /// which contains data needed for the login porcess. 
    /// </summary>
    public class LoginModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
