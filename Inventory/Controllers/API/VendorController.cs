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
    public class VendorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IActionResult> GetVendor()
        {
            List<Vendor> Items = await _context.Vendor.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Vendor> payload)
        {
            Vendor vendor = payload.value;
            _context.Vendor.Add(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Vendor> payload)
        {
            Vendor vendor = payload.value;
            _context.Vendor.Update(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Vendor> payload)
        {
            Vendor vendor = _context.Vendor
                .Where(x => x.VendorId == (int)payload.key)
                .FirstOrDefault();
            _context.Vendor.Remove(vendor);
            _context.SaveChanges();
            return Ok(vendor);

        }
    }
}