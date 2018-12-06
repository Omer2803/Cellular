﻿using System.Collections.Generic;
using Cellular.Common.Models;

namespace Cellular.Common.CRM
{
    public interface ILinesManager
    {
        void AddLine(int clientId, Line line);

        void AddPackage(Package package);

        Package EditPackage(Package package);
        List<Line> GetLinesByClientId(int clientId);
    }
}
