using Cellular.Common.CRM;
using Cellular.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.CRM.DAL
{
    public class LinesPackagesRepository : ILinesPackagesRepository
    {
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void AddPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(string lineNumber)
        {
            throw new NotImplementedException();
        }

        public void DeletePackage(int packageId)
        {
            throw new NotImplementedException();
        }

        public void EditPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public Line[] GetLinesOfClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Package GetPackageOfLine(string lineNumber)
        {
            throw new NotImplementedException();
        }
    }
}
