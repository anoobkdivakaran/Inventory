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
    public class PaymentTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentType
        [HttpGet]
        public async Task<IActionResult> GetPaymentType()
        {
            List<PaymentType> Items = await _context.PaymentType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PaymentType> payload)
        {
            PaymentType paymentType = payload.value;
            _context.PaymentType.Add(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PaymentType> payload)
        {
            PaymentType paymentType = payload.value;
            _context.PaymentType.Update(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PaymentType> payload)
        {
            PaymentType paymentType = _context.PaymentType
                .Where(x => x.PaymentTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();
            return Ok(paymentType);

        }
    }
}