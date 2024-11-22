using System;
using CentiroHomeAssignment.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CentiroHomeAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        string fileTypeToLoad = "";

        public OrdersController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
            fileTypeToLoad = _config["FileTypeToLoad"].ToString();
        }

        public IActionResult GetAll()
        {
            List<FileModel> lst = DataLoadService(fileTypeToLoad);
            return View(lst);
        }

        public IActionResult GetByOrderNumber(string orderNumber)
        {
            List<FileModel> lst = DataLoadService(fileTypeToLoad);
            lst = lst.Where(x => x.OrderNumber == orderNumber).ToList();
            return View(lst);
        }

        public List<FileModel> DataLoadService(string fileTypeToLoad)
        {
            var allRecords = new List<FileModel>();

            string currentDir = Environment.CurrentDirectory;
            string app_Data_Path = Path.Combine(currentDir, "App_Data");

            DirectoryInfo d = new DirectoryInfo(app_Data_Path);

            FileInfo[] filePaths = d.GetFiles(fileTypeToLoad);

            for (int i = 0; i < filePaths.Length; i++)
            {
                var reader = new StreamReader(filePaths[i].ToString());

                var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "|" });

                var records = csv.GetRecords<FileModel>().ToList();
                allRecords.AddRange(records);
            }
            return allRecords;
        }
    }
}
