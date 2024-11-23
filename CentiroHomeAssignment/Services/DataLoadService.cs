using CentiroHomeAssignment.Interface;
using CentiroHomeAssignment.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CentiroHomeAssignment.Services
{
    public class DataLoadService : IDataLoadService
    {
        private readonly ILogger<DataLoadService> _logger;

        public DataLoadService()
        {
                
        }
        public DataLoadService(ILogger<DataLoadService> log)
        {
            _logger = log;
        }

        /// <summary>
        /// This method reads the data from the file. Place the file in App_data folder to pick files to read. 
        /// </summary>
        /// <param name="fileTypeToLoad"></param>
        /// <returns>All data from the input files</returns>
        public List<FileModel> DataLoad(string fileTypeToLoad)
        {
            try
            {
                var allRecords = new List<FileModel>();

                string currentDir = Environment.CurrentDirectory;
                string app_Data_Path = Path.Combine(currentDir, "App_Data");

                //Input folder to read files is App_Data
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
            catch (Exception ex) {
                _logger.LogInformation(ex.ToString());
                throw; 
            }
        }
    }
}
