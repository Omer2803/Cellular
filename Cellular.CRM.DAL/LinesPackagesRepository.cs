using Cellular.Common.CRM;
using Cellular.Common.Models;
using Cellular.MainDal;
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
            using (var db = new CellularDbContext())
            {
                db.Lines.Add(line);
                db.SaveChanges();
            }
        }

        public void AddPackage(Package package)
        {
            using (var db = new CellularDbContext())
            {
                db.Packages.Add(package);
                db.SaveChanges();
            }
        }

        public void DeleteLine(string lineNumber)
        {
            using (var db = new CellularDbContext())
            {
                var lineRemoved = db.Lines.FirstOrDefault(l => l.PhoneNumber == lineNumber);
                db.Lines.Remove(lineRemoved);
                db.SaveChanges();
            }
        }

        public void DeletePackage(int packageId)
        {
            using (var db = new CellularDbContext())
            {
                var packageRemoved = db.Packages.FirstOrDefault(p => p.Id == packageId);
                db.Packages.Remove(packageRemoved);
                db.SaveChanges();
            }
        }

        public Package EditPackage(Package package)
        {
            using (var db = new CellularDbContext())
            {
                var packageEdited = db.Packages.FirstOrDefault(p => p.Id == package.Id);
                db.Entry(packageEdited).CurrentValues.SetValues(package);
                db.SaveChanges();
                return packageEdited;
            }
        }

        public List<Line> GetLinesOfClient(int clientId)
        {
            using (var db = new CellularDbContext())
            {
                return db.Lines.Where(l => l.ClientId == clientId).ToList();
            }
        }

        public Package GetPackageOfLine(string lineNumber)
        {
            using (var db = new CellularDbContext())
            {
                return db.Packages.FirstOrDefault(p => p.LineNumber == lineNumber);
            }
        }

       
    }
}
