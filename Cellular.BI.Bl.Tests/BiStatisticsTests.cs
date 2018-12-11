using System;
using System.Collections.Generic;
using Cellular.BI.BL;
using Cellular.Common.BI;
using Cellular.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using Cellular.Common.BI.Models;

namespace Cellular.BI.Bl.Tests
{
    [TestClass]
    public class BiStatisticsTests
    {
       private List<Employee> employees;
       private List<Client> clients;

        public BiStatisticsTests()
        {
            employees = new List<Employee>();
            employees.AddRange(new[]
            {
                new Employee
                {
                 Id = 1
                },
                new Employee
                {
                   Id=2
                }
            });
            clients = new List<Client>();
            clients.AddRange(new[]
           {
                new Client
                {
                 Id = 1,
                  ClientTypeId = ClientTypeEnum.Business,
                   RegisteredBy = 1
                },
                new Client
                {
                    Id = 2,
                  ClientTypeId = ClientTypeEnum.Business,
                   RegisteredBy = 1
                },
                 new Client
                {
                    Id = 3,
                  ClientTypeId = ClientTypeEnum.Business,
                   RegisteredBy = 1
                },
                  new Client
                {
                    Id = 4,
                  ClientTypeId = ClientTypeEnum.Business,
                   RegisteredBy = 2
                }
            });

        }

        [TestMethod]
        public void BestSellers_ReturnID_1_IsBestSeller()
        {
            //arrange
            var mock = new Mock<IBIRepository>();
            var biStatistics = new BIStatistics(mock.Object);

            //act
            mock.Setup(x => x.BestSellers(5)).Returns(new BestSeller[]
            {

            });


            var bestSellers = biStatistics.BestSellers(5);
            var bestSeller = bestSellers[0];


            //asert
            Assert.AreEqual(bestSeller.EmployeeId, 1);


        }
    }
}
