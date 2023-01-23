using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Debit_Credit.Models;

namespace Debit_Credit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmountTkClassesController : ControllerBase
    {
        private readonly DebitDbContext _context;

        public AmountTkClassesController(DebitDbContext context)
        {
            _context = context;
        }

        // GET: api/AmountTkClasses
        [HttpGet]
        [Route("AAll")]
        public async Task<ActionResult<IEnumerable<AmountTkClass>>> GetAmountTB()
        {
            return await _context.AmountTB.ToListAsync();
        }

        // GET: api/AmountTkClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmountTkClass>> GetAmountTkClass(int id)
        {
            var amountTkClass = await _context.AmountTB.FindAsync(id);

            if (amountTkClass == null)
            {
                return NotFound();
            }

            return amountTkClass;
        }

        // PUT: api/AmountTkClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmountTkClass(int id, AmountTkClass amountTkClass)
        {
            if (id != amountTkClass.amountId)
            {
                return BadRequest();
            }

            _context.Entry(amountTkClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmountTkClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AmountTkClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AmountTkClass>> PostAmountTkClass(AmountTkClass amountTkClass)
        {
            _context.AmountTB.Add(amountTkClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmountTkClass", new { id = amountTkClass.amountId }, amountTkClass);
        }

        // DELETE: api/AmountTkClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AmountTkClass>> DeleteAmountTkClass(int id)
        {
            var amountTkClass = await _context.AmountTB.FindAsync(id);
            if (amountTkClass == null)
            {
                return NotFound();
            }

            _context.AmountTB.Remove(amountTkClass);
            await _context.SaveChangesAsync();

            return amountTkClass;
        }

        private bool AmountTkClassExists(int id)
        {
            return _context.AmountTB.Any(e => e.amountId == id);
        }
    }
}
