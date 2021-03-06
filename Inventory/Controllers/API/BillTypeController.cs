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
    public class BillTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillType
        [HttpGet]
        public async Task<IActionResult> GetBillType()
        {
            List<BillType> Items = await _context.BillType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<BillType> payload)
        {
            BillType billType = payload.value;
            _context.BillType.Add(billType);
            _context.SaveChanges();
            return Ok(billType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<BillType> payload)
        {
            BillType billType = payload.value;
            _context.BillType.Update(billType);
            _context.SaveChanges();
            return Ok(billType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<BillType> payload)
        {
            BillType billType = _context.BillType
                .Where(x => x.BillTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.BillType.Remove(billType);
            _context.SaveChanges();
            return Ok(billType);

        }
    }
}
