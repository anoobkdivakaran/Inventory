using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Areas.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            List<Customer> Items = await _context.Customer.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = _context.Customer
                .Where(x => x.CustomerId == (int)payload.key)
                .FirstOrDefault();
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);

        }
    }
}