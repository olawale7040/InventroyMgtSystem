using InventroyMgtSystem.Data;
using InventroyMgtSystem.Models;
using InventroyMgtSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Repository
{
    public class InventoryItemRepository : Repository<InventoryItem>, IInventoryItem
    {
        private readonly ApplicationDbContext _db;
        public InventoryItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCategoryListOfDropDown()
        {
            var selectList = _db.InventoryItem.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            return selectList;
        }
        public void Update(InventoryItem inventoryItem)
        {
            var objFromDb = _db.InventoryItem.FirstOrDefault(c => c.Id == inventoryItem.Id);
            objFromDb.Name = inventoryItem.Name;
            objFromDb.Description = inventoryItem.Description;
            objFromDb.Price = inventoryItem.Price;
            objFromDb.CategoryId = inventoryItem.CategoryId;
            _db.SaveChanges();
        }
    }
}
