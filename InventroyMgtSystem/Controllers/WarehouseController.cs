using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventroyMgtSystem.Models;
using InventroyMgtSystem.Models.ViewModels;
using InventroyMgtSystem.Repository.IRepository;
using InventroyMgtSystem.Utilitis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventroyMgtSystem.Controllers
{
    [Authorize(Roles = SD.WarehouseManager)]

    public class WarehouseController : Controller
    {
        private IAllDbSets _allDbSets;
        public WarehouseController(IAllDbSets allDbSets)
        {
            _allDbSets = allDbSets;
        }
        public IActionResult Index()
        {
            return View(new Warehouse());
        }

        public IActionResult UpSet(int? id)
        {
            var warehouseVM = new WarehouseViewModel()
            {
                InventoryItems = _allDbSets.InventoryItem.GetCategoryListOfDropDown(),
                Warehouse = new Warehouse(),
            };
            if (id != null)
            {
                var warehouseFromDB = _allDbSets.Warehouse.GetFisrtOrDefault(c => c.Id == id.GetValueOrDefault());
                if (warehouseFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    warehouseVM.Warehouse = warehouseFromDB;
                    return View(warehouseVM);
                }
            }
            else
            {
                return View(warehouseVM);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSet(WarehouseViewModel warehouseVM)
        {
            if (!ModelState.IsValid)
            {
                warehouseVM.InventoryItems = _allDbSets.InventoryItem.GetCategoryListOfDropDown();
                return View(warehouseVM);
            }
            else
            {
                if (warehouseVM.Warehouse.Id != 0)
                {
                    _allDbSets.Warehouse.Update(warehouseVM.Warehouse);
                }
                else
                {
                    var checkWarehouse = _allDbSets.Warehouse.GetFisrtOrDefault(w => w.ItemId == warehouseVM.Warehouse.ItemId);
                    if (checkWarehouse == null)
                    {
                        warehouseVM.Warehouse.DateAdded = DateTime.Now;
                        _allDbSets.Warehouse.Add(warehouseVM.Warehouse);
                    }
                    else
                    {
                        checkWarehouse.Quantity = warehouseVM.Warehouse.Quantity + checkWarehouse.Quantity;
                    }
                }
                _allDbSets.Save();
                return RedirectToAction(nameof(Index));
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var warehouseFromDb = _allDbSets.Warehouse.GetFisrtOrDefault(c => c.Id == id);
            if (warehouseFromDb != null)
            {
                _allDbSets.Warehouse.Remove(warehouseFromDb);
                _allDbSets.Save();
                return Json(new { status = true, message = "Delete Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Unable to delete" });
            }
        }
        public IActionResult GetAll()
        {
            var warehouse = _allDbSets.Warehouse.GetAll(null,null, "InventoryItem"); 
            return Json(new { data = warehouse });
        }
    }
}