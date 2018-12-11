using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface ILinesManager
    {
        /// <summary>
        /// Add new line
        /// </summary>
        /// <param name="line"></param>
        void AddLine(Line line);
        /// <summary>
        /// Add new package to line
        /// </summary>
        /// <param name="package"></param>
        void AddPackage(Package package);
        /// <summary>
        /// Gets the package of his phone number
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        Package GetPackageOfLine(string lineNumber);
        /// <summary>
        /// Edit package details
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        Package EditPackage(Package package);
        /// <summary>
        /// Get all lines by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        List<Line> GetLinesByClientId(int clientId);
    }
}
