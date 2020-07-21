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

    public class InventoryItemsController : Controller
    {
        private IAllDbSets _allDbSets;
        public InventoryItemsController(IAllDbSets allDbSets)
        {
            _allDbSets = allDbSets;
        }
        public IActionResult Index()
        {
            return View(new InventoryItem());
        }

        public IActionResult UpSet(int? id)
        {
            var InventoryVM = new InventoryViewModel() {
                Category = _allDbSets.Category.GetCategoryListOfDropDown(),
                InventoryItem = new InventoryItem(),
                    };
            if (id != null)
            {
               var itemFromDB = _allDbSets.InventoryItem.GetFisrtOrDefault(c => c.Id == id.GetValueOrDefault());
                if (itemFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    InventoryVM.InventoryItem = itemFromDB;
                    return View(InventoryVM);
                }
            }
            else
            {
                return View(InventoryVM);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSet(InventoryViewModel inventoryVm)
        {
            if (!ModelState.IsValid)
            {
                inventoryVm.Category = _allDbSets.Category.GetCategoryListOfDropDown();
                return View(inventoryVm);
            }
            else
            {
                if (inventoryVm.InventoryItem.Id != 0)
                {
                    _allDbSets.InventoryItem.Update(inventoryVm.InventoryItem);
                }
                else
                {
                    _allDbSets.InventoryItem.Add(inventoryVm.InventoryItem);
                }
                _allDbSets.Save();
                return RedirectToAction(nameof(Index));
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var inventoryFromDb = _allDbSets.InventoryItem.GetFisrtOrDefault(c => c.Id == id);
            if (inventoryFromDb != null)
            {
                _allDbSets.InventoryItem.Remove(inventoryFromDb);
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
            var inventoryItem = _allDbSets.InventoryItem.GetAll(null, null, "Category");
            return Json(new { data = inventoryItem });
        }
    }
}