using System;

namespace Cellular.Common.Invoices.Models
{
    [Flags]
    public enum LoginResultEnum
    {
        IdDoesNotExist = 1,
        WrongPassword = 2,
        //Failed = IdDoesNotExist | WrongPassword,
        Client = 4,
        Employee = 8,
        //Succeeded = Client | Employee
    }
}
