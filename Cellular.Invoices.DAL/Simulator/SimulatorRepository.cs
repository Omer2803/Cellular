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
                switch (destinationOption)
                {
                    case DestinationOption.Friends:
                        var pack = context.Packages.FirstOrDefault(p => p.LineNumber == number);
                        if (pack != null && pack.IncludesFriends)
                            return new string[] { pack.Number1, pack.Number2, pack.Number3 };
                        throw new InvalidOperationException("The given line does not have a package or its does not includ friends. ");

                    case DestinationOption.All:
                        Random rand = new Random();
                        var result = new string[amount];
                        var count = context.Lines.Count();

                        for (int i = 0; i < amount;)
                        {
                            var temp = context.Lines.ElementAt(rand.Next(count)).PhoneNumber;
                            if (temp != number) result[i++] = temp;
                        }

                        return result;

                    default: throw new NotSupportedException();
                }
            }
        }
    }
}
