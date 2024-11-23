using CentiroHomeAssignment.Interface;
using CentiroHomeAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CentiroHomeAssignment.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IDataLoadService _dataLoadService;
        string fileTypeToLoad = "";

        public OrdersController(IConfiguration configuration, IDataLoadService dataLoadService)
        {
            _config = configuration;
            _dataLoadService = dataLoadService;
            
            fileTypeToLoad = _config["FileTypeToLoad"].ToString();
        }

        public IActionResult GetAll()
        {
            List<FileModel> lst = _dataLoadService.DataLoad(fileTypeToLoad);
            return View(lst);
        }

        [HttpGet("{orderNumber}")]
        public IActionResult GetByOrderNumber(string orderNumber)
        {
            List<FileModel> lst = _dataLoadService.DataLoad(fileTypeToLoad);
            lst = lst.Where(x => x.OrderNumber == orderNumber).ToList();
            return View(lst);
        }
    }
}
