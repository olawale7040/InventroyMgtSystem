﻿using InventroyMgtSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventroyMgtSystem.Repository.IRepository
{
    public interface IWarehouse : IRepository<Warehouse>
    {
        void Update(Warehouse warehouse);
    }
}
