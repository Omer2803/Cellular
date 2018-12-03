using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.BL
{
    public class LinesManager : ILinesManager
    {
        public LinesManager(ILinesPackagesRepository repository)
        {
            Repository = repository;
        }

        public ILinesPackagesRepository Repository { get; }

        public void AddLine(int clientId, Line line)
        {
            throw new NotImplementedException();
        }

        public void AddPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public void EditPackage(Package package)
        {
            throw new NotImplementedException();
        }
    }
}
