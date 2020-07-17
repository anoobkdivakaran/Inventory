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
    public class CustomerTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: api/CustomerType
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            List<CustomerType> Items = await _context.CustomerType.ToListAsync();
            return Json(Items);
        }

        public IActionResult Insert(string models)
        {
            CustomerType customerType = JsonConvert.DeserializeObject<List<CustomerType>>(models).FirstOrDefault();
            _context.CustomerType.Add(customerType);
            _context.SaveChanges();
            return Ok(customerType);
        }


        public IActionResult Update(string models)
        {
            CustomerType customerType = JsonConvert.DeserializeObject<List<CustomerType>>(models).FirstOrDefault();
            _context.CustomerType.Update(customerType);
            _context.SaveChanges();
            return Ok(customerType);
        }

        public IActionResult Remove(string models)
        {
            CustomerType customerType = _context.CustomerType
                .Where(x => x.CustomerTypeId == JsonConvert.DeserializeObject<List<CustomerType>>(models).FirstOrDefault().CustomerTypeId)
                .FirstOrDefault();
            _context.CustomerType.Remove(customerType);
            _context.SaveChanges();
            return Ok(customerType);

        }
    }
}