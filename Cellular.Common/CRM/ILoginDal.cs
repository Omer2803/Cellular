using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.CRM
{
    public interface ILoginDal
    {
        Employee Login(int Id, string password);
    }
}
