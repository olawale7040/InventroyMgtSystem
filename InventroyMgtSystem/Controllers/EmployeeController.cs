using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventroyMgtSystem.Models;
using InventroyMgtSystem.Repository.IRepository;
using InventroyMgtSystem.Utilitis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventroyMgtSystem.Controllers
{
    [Authorize(Roles = SD.WarehouseManager)]

    public class EmployeeController : Controller
    {
        private IAllDbSets _allDbSets;
        public EmployeeController(IAllDbSets allDbSets)
        {
            _allDbSets = allDbSets;
        }
        public IActionResult Index()
        {
            return View(new Employee());
        }




        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult LockUnlock(string id)
        {
            var objFromDb = _allDbSets.Employee.GetFisrtOrDefault(c => c.Id == id);
            if (objFromDb != null)
            {
                if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
                {
                    objFromDb.LockoutEnd = DateTime.Now;
                }
                else
                {
                    objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
                }
                _allDbSets.Save();
                return Json(new { status = true, message = "Operation Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Operation Failed" });
            }
        }
        public IActionResult GetAll()
        {
            var employee = _allDbSets.Employee.GetAll();
            return Json(new { data = employee });
        }
    }
}