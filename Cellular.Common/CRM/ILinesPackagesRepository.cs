using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface ILinesPackagesRepository
    {
        Package GetPackageOfLine(string lineNumber);

        void AddPackage(Package package);

        Package EditPackage(Package package);

        void DeletePackage(int packageId);

        List<Line> GetLinesOfClient(int clientId);

        void AddLine(Line line);

        void DeleteLine(string lineNumber);
    }
}
