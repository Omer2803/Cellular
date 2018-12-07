using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface ILinesManager
    {
        void AddLine(Line line);

        void AddPackage(Package package);

        Package GetPackageOfLine(string lineNumber);

        Package EditPackage(Package package);
        List<Line> GetLinesByClientId(int clientId);
    }
}
