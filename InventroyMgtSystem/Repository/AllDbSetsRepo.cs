using InventroyMgtSystem.Data;
using InventroyMgtSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Repository
{
    public class AllDbSetsRepo : IAllDbSets
    {
        private readonly ApplicationDbContext _db;
        public AllDbSetsRepo(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Employee = new EmployeeRepository(_db);
            Warehouse = new WarehouseRepository(_db);
            InventoryItem = new InventoryItemRepository(_db);
            SuppliedGood = new SuppliedGoodRepository(_db);
        }
        public ICategory Category { get; private set; }

        public IEmployee Employee { get; private set; }

        public IInventoryItem InventoryItem { get; private set; }

        public ISuppliedGood SuppliedGood { get; private set; }

        public IWarehouse Warehouse { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
