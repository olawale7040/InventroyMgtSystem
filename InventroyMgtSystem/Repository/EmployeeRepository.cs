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
    public class EmployeeRepository : Repository<Employee>, IEmployee
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
