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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CentiroHomeAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;

        }

        public IActionResult Index()
        {
            string fileTypeToLoad = _config["FileTypeToLoad"].ToString();
            List<FileModel> lst = DataLoadService(fileTypeToLoad);
            return View(lst);
        }

        public List<FileModel> DataLoadService(string fileTypeToLoad)
        {
            var allRecords = new List<FileModel>();

            string currentDir = Environment.CurrentDirectory;
            string app_Data_Path = Path.Combine(currentDir, "App_Data");

            DirectoryInfo d = new DirectoryInfo(app_Data_Path);

            FileInfo[] filePaths = d.GetFiles(fileTypeToLoad);

            for(int i=0; i<filePaths.Length; i++)
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
