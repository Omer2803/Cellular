﻿using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface IAuthenticator
    {
        Employee Login(int Id, string password);

        void Logout(int employeeId);
    }
}