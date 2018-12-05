using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using Cellular.Common.Models;
using System;

namespace Cellular.Invoices.BL.Simulator
{
    public class Simulator : ISimulator
    {
        private readonly ISimulatorRepository repository;

        public Simulator(ISimulatorRepository repository)
        {
            this.repository = repository;
        }

        public void SimulateCalls(SimulatorCalls calls)
        {
            string[] dests = repository.GetRandomNumbersFor(calls.CallerNumber, calls.DestinationOption, calls.Simulations);

            Random rand = new Random();

            var rangeLength = (calls.MaxDuration - calls.MinDuration).TotalMinutes;
            var minDur = calls.MinDuration.TotalMinutes;

            var time = DateTime.Now;

            for (int i = 0; i < calls.Simulations; i++)
            {
                repository.AddCall(new Call
                {
                    CallerNumber = calls.CallerNumber,
                    DestinationNumber = dests[i],
                    Duration = TimeSpan.FromMinutes((rand.Next() / (double)int.MaxValue) * rangeLength + minDur),
                    StartTime = time
                });

                time = time.AddMinutes(5);
            }
        }

        public void SimulateSMSes(SimulatorSMSes smses)
        {
            string[] dests = repository.GetRandomNumbersFor(smses.SenderNumber, smses.DestinationOption, smses.Simulations);

            var time = DateTime.Now;

            for (int i = 0; i < smses.Simulations; i++)
            {
                repository.AddSMS(new SMS
                {
                    SenderNumber = smses.SenderNumber,
                    DestinationNumber = dests[i],
                    SendingTime = time
                });

                time = time.AddMinutes(5);
            }
        }

        public string[] NumbersOf(int clientId)
        {
            return repository.NumbersOf(clientId);
        }
    }
}
