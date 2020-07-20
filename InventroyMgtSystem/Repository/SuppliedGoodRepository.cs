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
    public class SuppliedGoodRepository : Repository<SuppliedGood>, ISuppliedGood
    {
        private readonly ApplicationDbContext _db;
        public SuppliedGoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SuppliedGood suppliedGood)
        {
            var objFromDb = _db.SuppliedGood.FirstOrDefault(c => c.Id == suppliedGood.Id);
            objFromDb.ItemId = suppliedGood.ItemId;
            objFromDb.Quantity = suppliedGood.Quantity;
            _db.SaveChanges();
        }
    }
}
