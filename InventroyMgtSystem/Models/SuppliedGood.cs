using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Models
{
    public class SuppliedGood
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual InventoryItem InventroyItem { get; set; }

        public int Quantity { get; set; }

        public DateTime DateSupplied { get; set; }
    }
}
