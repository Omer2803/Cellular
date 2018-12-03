using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface ILinesManager
    {
        void AddLine(int clientId, Line line);

        void AddPackage(Package package);

        void EditPackage(Package package);
    }
}
