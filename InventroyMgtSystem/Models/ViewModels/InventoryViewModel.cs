using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Models.ViewModels
{
    public class InventoryViewModel
    {
        public InventoryItem InventoryItem { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
