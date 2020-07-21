using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InventroyMgtSystem.Models;
using InventroyMgtSystem.Models.ViewModels;
using InventroyMgtSystem.Repository.IRepository;

namespace InventroyMgtSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAllDbSets _allDbSets;
        public HomeController(ILogger<HomeController> logger, IAllDbSets allDbSets)
        {
            _logger = logger;
            _allDbSets = allDbSets;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/Identity/Account/Login");
            }
            else { 
            var homeVM = new HomeViewModel()
            {
                WarehouseList = _allDbSets.Warehouse.GetAll(null,null, "InventoryItem").ToList(),
                CategoryList = _allDbSets.Category.GetAll().ToList(),
            };
            return View(homeVM);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
