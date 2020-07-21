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
    [Authorize(Roles =SD.WarehouseManager)]
    public class CategoriesController : Controller
    {
        private IAllDbSets _allDbSets;
        public CategoriesController(IAllDbSets allDbSets)
        {
            _allDbSets = allDbSets;
        }
        public IActionResult Index()
        {
            return View(new Category());
        }

        public IActionResult UpSet(int? id)
        {
            var category = new Category();
            if (id != null)
            {
               var categoryFromDB = _allDbSets.Category.GetFisrtOrDefault(c => c.Id == id.GetValueOrDefault());
                if (categoryFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    category = categoryFromDB;
                    return View(category);
                }
            }
            else
            {
                return View(category);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSet(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                if (category.Id != 0)
                {
                    _allDbSets.Category.Update(category);
                }
                else
                {
                    _allDbSets.Category.Add(category);
                }
                _allDbSets.Save();
                return RedirectToAction(nameof(Index));
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryFromDb = _allDbSets.Category.GetFisrtOrDefault(c => c.Id == id);
            if (categoryFromDb != null)
            {
                _allDbSets.Category.Remove(categoryFromDb);
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
            var categories = _allDbSets.Category.GetAll();
            return Json(new { data = categories });
        }
    }
}