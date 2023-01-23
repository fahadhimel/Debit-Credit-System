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
    public class DebitModelsClassesController : ControllerBase
    {
        private readonly DebitDbContext _context;

        public DebitModelsClassesController(DebitDbContext context)
        {
            _context = context;
        }

        // GET: api/DebitModelsClasses
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<DebitModelsClass>>> GetDebitTB()
        {
            return await _context.DebitTB.ToListAsync();
        }

        // GET: api/DebitModelsClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DebitModelsClass>> GetDebitModelsClass(int id)
        {
            var debitModelsClass = await _context.DebitTB.FindAsync(id);

            if (debitModelsClass == null)
            {
                return NotFound();
            }

            return debitModelsClass;
        }

        // PUT: api/DebitModelsClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebitModelsClass(int id, DebitModelsClass debitModelsClass)
        {
            if (id != debitModelsClass.DebitID)
            {
                return BadRequest();
            }

            _context.Entry(debitModelsClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitModelsClassExists(id))
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

        // POST: api/DebitModelsClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("typepost")]
        public async Task<ActionResult<DebitModelsClass>> PostDebitModelsClass(DebitModelsClass debitModelsClass)
        {
            _context.DebitTB.Add(debitModelsClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDebitModelsClass", new { id = debitModelsClass.DebitID }, debitModelsClass);
        }

        // DELETE: api/DebitModelsClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DebitModelsClass>> DeleteDebitModelsClass(int id)
        {
            var debitModelsClass = await _context.DebitTB.FindAsync(id);
            if (debitModelsClass == null)
            {
                return NotFound();
            }

            _context.DebitTB.Remove(debitModelsClass);
            await _context.SaveChangesAsync();

            return debitModelsClass;
        }

        private bool DebitModelsClassExists(int id)
        {
            return _context.DebitTB.Any(e => e.DebitID == id);
        }
    }
}
