using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CentiroHomeAssignment.Models;
using System.Collections.Generic;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO;
using System;
using System.Linq;

namespace CentiroHomeAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<FileModel> lst = CSVService();
            return View(lst);
        }

        public List<FileModel> CSVService()
        {
            var allRecords = new List<FileModel>();

            var filePaths = new List<string> { @"C:\Users\ksand\Downloads\CentiroHomeAssignment\CentiroHomeAssignment\App_Data\Order1.csv",
                @"C:\Users\ksand\Downloads\CentiroHomeAssignment\CentiroHomeAssignment\App_Data\Order2.csv",
                @"C:\Users\ksand\Downloads\CentiroHomeAssignment\CentiroHomeAssignment\App_Data\Order3.csv" };

            //var filePath = @"C:\Users\ksand\Downloads\CentiroHomeAssignment\CentiroHomeAssignment\App_Data\Order1.csv";

            foreach (var filePath in filePaths)
            {
                var reader = new StreamReader(filePath);

                var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "|" });

                var records = csv.GetRecords<FileModel>().ToList();
                allRecords.AddRange(records);
            }
            return allRecords;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
