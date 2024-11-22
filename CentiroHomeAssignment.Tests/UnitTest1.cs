using CentiroHomeAssignment.Controllers;
using CentiroHomeAssignment.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CentiroHomeAssignment.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckIfModelHoldsMultipleRows()
        {
            List<FileModel> list = new List<FileModel>();

            list.Add(new FileModel { CustomerName = "customerName", CustomerNumber = "1001", Description = "Description", Name = "testName", 
                OrderDate= new System.DateTime(2024-01-01), OrderLineNumber =100, OrderNumber="101", Price = 100.99m, ProductGroup = "testGrp",  
                ProductNumber = "A0001AS", Quantity =25});

            list.Add(new FileModel
            {
                CustomerName = "customerName2",
                CustomerNumber = "1002",
                Description = "Description",
                Name = "testName2",
                OrderDate = new System.DateTime(2024 - 01 - 02),
                OrderLineNumber = 101,
                OrderNumber = "102",
                Price = 200.99m,
                ProductGroup = "testGrp2",
                ProductNumber = "A0001AS2",
                Quantity = 250
            });

            list.Add(new FileModel
            {
                CustomerName = "customerName3",
                CustomerNumber = "1003",
                Description = "Description",
                Name = "testName3",
                OrderDate = new System.DateTime(2024 - 02 - 01),
                OrderLineNumber = 103,
                OrderNumber = "103",
                Price = 300.99m,
                ProductGroup = "testGrp3",
                ProductNumber = "A0001AS3",
                Quantity = 33
            });

                Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void CheckAppDataExists()
        {
            string currentDir = Environment.CurrentDirectory;
            string app_Data_Path = Path.Combine(currentDir, "App_Data");
            Assert.IsTrue(app_Data_Path.Length > 0);
        }
    }
}
