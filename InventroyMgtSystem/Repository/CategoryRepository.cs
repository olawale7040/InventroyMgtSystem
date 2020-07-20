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
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetCategoryListOfDropDown()
        {
            var selectList = _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            return selectList;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(c => c.Id == category.Id);
            objFromDb.Name = category.Name;
            _db.SaveChanges();
        }
    }
}
