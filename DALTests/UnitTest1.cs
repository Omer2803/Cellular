using System;
using Cellular.MainDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new CellularDbContext())
            {
                context.Database.Create();
            }
        }
    }
}
