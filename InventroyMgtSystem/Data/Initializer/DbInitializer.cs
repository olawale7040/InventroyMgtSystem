
using InventroyMgtSystem.Models;
using InventroyMgtSystem.Utilitis;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
            

        }
        public void Initizer()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            if (_db.Roles.Any(r => r.Name == SD.WarehouseManager)) return;
            _roleManager.CreateAsync(new IdentityRole(SD.WarehouseWorker)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.MaterialHandler)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.WarehouseManager)).GetAwaiter().GetResult();
            _db.Category.Add(new Category { Name = SD.Category });
            _db.Category.Add(new Category { Name = SD.CatgoryB });
            _db.SaveChanges();

            _userManager.CreateAsync(new Employee
            {
                UserName = "olawale7040@gmail.com",
                Email = "olawale7040@gmail.com",
                EmailConfirmed = true,
                FirstName = "Adekunle",
                LastName = "Nasman",
            }, "Admin123*").GetAwaiter().GetResult();

            var user = _db.Employee.Where(u => u.Email == "olawale7040@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(user, SD.WarehouseManager).GetAwaiter().GetResult();

        }
    }

}
