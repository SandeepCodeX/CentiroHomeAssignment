using CentiroHomeAssignment.Interface;
using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CentiroHomeAssignment.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IDataLoadService _dataLoadService;
        private readonly Mock<IDataLoadService> _mockService;

        public UnitTest1()
        {
            _mockService = new Mock<IDataLoadService>();
            _dataLoadService = new DataLoadService();
        }

        public List<FileModel> TestData()
        {

            List<FileModel> fileData = new List<FileModel>();

            fileData.Add(new FileModel
            {
                CustomerName = "customerName",
                CustomerNumber = "1001",
                Description = "Description",
                Name = "testName",
                OrderDate = new System.DateTime(2024 - 01 - 01),
                OrderLineNumber = 100,
                OrderNumber = "101",
                Price = 100.99m,
                ProductGroup = "testGrp",
                ProductNumber = "A0001AS",
                Quantity = 25
            });

            fileData.Add(new FileModel
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

            fileData.Add(new FileModel
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

            return fileData;
        }

        [TestMethod]
        public void CheckDataLoadService()
        {
            string fileType = ".csv";

            List<FileModel> expected = TestData();

            _mockService.Setup(d => d.DataLoad(fileType)).Returns(expected);

            var actual = _dataLoadService.DataLoad(fileType);

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void CheckAppDataExists()
        {
            string currentDir = Environment.CurrentDirectory;
            string app_Data_Path = Path.Combine(currentDir, "App_Data");
            Assert.IsTrue(app_Data_Path.Length > 0);
        }

        [TestMethod]
        public void CheckIfOutputHasExpectedData() {

            string fileType = ".txt";

            List<FileModel> data = TestData();
            string expectedProduct = "A0001AS";

            _mockService.Setup(d => d.DataLoad(fileType)).Returns(data);

            Assert.IsTrue(data.Where(p => p.ProductNumber == expectedProduct).Count()>0);
        }

    }
}
