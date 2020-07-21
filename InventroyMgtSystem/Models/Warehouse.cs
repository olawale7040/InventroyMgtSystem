using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Models
{
    public class Warehouse
    {
        public Warehouse()
        {
            Quantity = 1;
        }
        public int Id { get; set; }

        [Display(Name = "Inventory Item")]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual InventoryItem  InventoryItem { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }

        public string EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }


    }
}
