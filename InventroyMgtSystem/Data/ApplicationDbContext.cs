using System;
using System.Collections.Generic;
using System.Text;
using InventroyMgtSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventroyMgtSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        
        public DbSet<InventoryItem> InventoryItem { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }

        public DbSet<SuppliedGood> SuppliedGood { get; set; }

    }
}
