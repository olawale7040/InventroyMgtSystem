using InventroyMgtSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Repository.IRepository
{

    public interface IAllDbSets : IDisposable
    {
        ICategory Category { get; }
        IEmployee Employee { get; }

        IInventoryItem InventoryItem { get; }

        ISuppliedGood SuppliedGood { get; }

        IWarehouse Warehouse { get; }

        void Save();
    }
    }
