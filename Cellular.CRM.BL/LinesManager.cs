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
        private readonly ILinesPackagesRepository _linesPackagesRepository;

        public LinesManager(ILinesPackagesRepository  linesPackagesRepository)
        {
            this._linesPackagesRepository = linesPackagesRepository;
        }

        public void AddLine(int clientId, Line line)
        {
            _linesPackagesRepository.AddLine(line);
        }

        public void AddPackage(Package package)
        {
            _linesPackagesRepository.AddPackage(package);
        }

        public Package EditPackage(Package package)
        {
            return _linesPackagesRepository.EditPackage(package);
        }
    }
}
