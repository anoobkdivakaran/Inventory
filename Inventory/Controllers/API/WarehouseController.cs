﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarehouseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Warehouse
        [HttpGet]
        public async Task<IActionResult> GetWarehouse()
        {
            List<Warehouse> Items = await _context.Warehouse.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Warehouse> payload)
        {
            Warehouse warehouse = payload.value;
            _context.Warehouse.Add(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Warehouse> payload)
        {
            Warehouse warehouse = payload.value;
            _context.Warehouse.Update(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Warehouse> payload)
        {
            Warehouse warehouse = _context.Warehouse
                .Where(x => x.WarehouseId == (int)payload.key)
                .FirstOrDefault();
            _context.Warehouse.Remove(warehouse);
            _context.SaveChanges();
            return Ok(warehouse);

        }
    }
}