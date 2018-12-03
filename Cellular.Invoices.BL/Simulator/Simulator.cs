using Cellular.Common.Invoices;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.Invoices.BL.Simulator
{
    public class Simulator : ISimulator
    {
        private readonly ISimulatorRepository repository;

        public Simulator(ISimulatorRepository repository)
        {
            this.repository = repository;
        }

        public void AddCall(Call call)
        {
            throw new NotImplementedException();
        }

        public void AddSMS(SMS sms)
        {
            throw new NotImplementedException();
        }
    }
}
