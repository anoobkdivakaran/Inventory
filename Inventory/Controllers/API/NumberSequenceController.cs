using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberSequenceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NumberSequenceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NumberSequence
        [HttpGet]
        public async Task<IActionResult> GetNumberSequence()
        {
            List<NumberSequence> Items = await _context.NumberSequence.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        // PUT: api/NumberSequence/5
        [HttpPut]
        public async Task<IActionResult> PutNumberSequence([FromBody] NumberSequence numberSequence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(numberSequence).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/NumberSequence
        [HttpPost]
        public async Task<IActionResult> PostNumberSequence([FromBody] NumberSequence numberSequence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.NumberSequence.Add(numberSequence);
            await _context.SaveChangesAsync();

            return Ok(numberSequence);
        }

        // DELETE: api/NumberSequence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumberSequence([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var numberSequence = await _context.NumberSequence.SingleOrDefaultAsync(m => m.NumberSequenceId == id);
            if (numberSequence == null)
            {
                return NotFound();
            }

            _context.NumberSequence.Remove(numberSequence);
            await _context.SaveChangesAsync();

            return Ok(numberSequence);
        }

        private bool NumberSequenceExists(int id)
        {
            return _context.NumberSequence.Any(e => e.NumberSequenceId == id);
        }

    }
}