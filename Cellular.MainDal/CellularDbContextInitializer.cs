using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular.MainDal
{
    class CellularDbContextInitializer : DropCreateDatabaseIfModelChanges<CellularDbContext>
    {
        protected override void Seed(CellularDbContext context)
        {
            
        }
    }
}
