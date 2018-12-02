using System;
using System.Collections.Generic;
using System.Text;

namespace Cellular.Common.Models
{
    public class ClientType
    {
        public ClientTypeEnum Id { get; set; }
        public double CallMinutesPrice { get; set; }
        public double SmsPrice { get; set; }
    }
}
