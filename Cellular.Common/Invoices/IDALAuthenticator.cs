﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Invoices
{
    public interface IDALAuthenticator
    {
        object GetClientOrEmployee(int id, string password);
    }
}
