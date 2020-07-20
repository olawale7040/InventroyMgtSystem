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
    public class WarehouseRepository : Repository<Warehouse>, IWarehouse
    {
        private readonly ApplicationDbContext _db;
        public WarehouseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Warehouse warehouse)
        {
            var objFromDb = _db.Warehouse.FirstOrDefault(c => c.Id == warehouse.Id);
            objFromDb.ItemId = warehouse.ItemId;
            objFromDb.Quantity = warehouse.Quantity;
            _db.SaveChanges();
        }
    }
}
