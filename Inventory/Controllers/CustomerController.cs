using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    //[Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: api/CustomerController
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var customerType = await _context.CustomerType.ToListAsync().ConfigureAwait(false);
            var customer = await _context.Customer.ToListAsync().ConfigureAwait(false);
            Customer customerModel = new Customer();
            List<Customer> Items = new List<Customer>();
            foreach (var item in customer)
            {
                customerModel = item;
                customerModel.CustomerType = customerType.Find(f => f.CustomerTypeId == item.CustomerTypeId);
                Items.Add(customerModel);
            }
            return Json(Items);
        }

        public IActionResult Insert(string models)
        {
            Customer customer = JsonConvert.DeserializeObject<List<Customer>>(models).FirstOrDefault();
            customer.CustomerTypeId = customer.CustomerType.CustomerTypeId;
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }


        public IActionResult Update(string models)
        {
            Customer customer = JsonConvert.DeserializeObject<List<Customer>>(models).FirstOrDefault();
            customer.CustomerTypeId = customer.CustomerType.CustomerTypeId;
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        public IActionResult Remove(string models)
        {
            var CustomerId = JsonConvert.DeserializeObject<List<Customer>>(models).FirstOrDefault()?.CustomerId ?? 0;
            Customer customer = _context.Customer
                .Where(x => x.CustomerId == CustomerId)
                .FirstOrDefault();
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);

        }
    }
}