using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Models.ViewModels
{
    public class WarehouseViewModel
    {
        public Warehouse Warehouse { get; set; }

        public IEnumerable<SelectListItem> InventoryItems { get; set; }
    }
}
