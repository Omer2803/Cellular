using Cellular.Common.Invoices;
using Cellular.Common.Invoices.Models;
using Cellular.Common.Models;
using Cellular.MainDal;
using System;
using System.Linq;

namespace Cellular.Invoices.DAL.Simulator
{
    public class SimulatorRepository : ISimulatorRepository
    {
        public void AddCall(Call call)
        {
            using (var context = new CellularDbContext())
            {
                context.Calls.Add(call);
                context.SaveChanges();
            }
        }

        public void AddSMS(SMS sms)
        {
            using (var context = new CellularDbContext())
            {
                context.SMSes.Add(sms);
                context.SaveChanges();
            }
        }

        public string[] NumbersOf(int clientId)
        {
            using (var context = new CellularDbContext())
            {
                return context.Lines
                    .Where(l => l.ClientId == clientId)
                    .Select(l => l.PhoneNumber)
                    .ToArray();
            }
        }

        public string[] FriendsOf(string lineNumber)
        {
            using (var context = new CellularDbContext())
            {
                var pack = context.Packages.FirstOrDefault(p => p.LineNumber == lineNumber);
                if (pack != null && pack.IncludesFriends)
                    return new string[] { pack.Number1, pack.Number2, pack.Number3 };
                return null;
            }
        }

        public string[] GetRandomNumbersFor(string number, DestinationOption destinationOption, int amount)
        {
            using (var context = new CellularDbContext())
            {
                string[] result;
                switch (destinationOption)
                {
                    case DestinationOption.Friends:
                        var pack = context.Packages.FirstOrDefault(p => p.LineNumber == number);
                        if (pack != null && pack.IncludesFriends)
                        {
                            result = new string[] { pack.Number1, pack.Number2, pack.Number3 };
                            break;
                        }
                        else return new string[0];
                    //throw new InvalidOperationException("The given line does not have a package or its does not includ friends. ");

                    case DestinationOption.All:
                        result = context.Lines
                            .Where(l => l.PhoneNumber != number)
                            .OrderBy(l => Guid.NewGuid())
                            .Take(amount)
                            .Select(l => l.PhoneNumber)
                            .ToArray();

                        break;

                    default: throw new NotSupportedException();
                }
                CompleteToAmount(ref result, amount);
                return result;
            }
        }

        private void CompleteToAmount(ref string[] numbers, int amount)
        {
            if (numbers.Length < amount)
            {
                int iterations = amount - numbers.Length;
                Random randIndex = new Random();
                var list = numbers.ToList();
                for (int i = 0; i < iterations; i++)
                    list.Add(numbers[randIndex.Next(numbers.Length)]);
                numbers = list.ToArray();
            }
        }
    }
}
