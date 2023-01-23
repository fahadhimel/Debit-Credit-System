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
    public class CreditModelsClassesController : ControllerBase
    {
        private readonly DebitDbContext _context;

        public CreditModelsClassesController(DebitDbContext context)
        {
            _context = context;
        }

        // GET: api/CreditModelsClasses
        [HttpGet]
        [Route("Alll")]
        public async Task<ActionResult<IEnumerable<CreditModelsClass>>> GetCreditTB()
        {
            return await _context.CreditTB.ToListAsync();
        }

        // GET: api/CreditModelsClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditModelsClass>> GetCreditModelsClass(int id)
        {
            var creditModelsClass = await _context.CreditTB.FindAsync(id);

            if (creditModelsClass == null)
            {
                return NotFound();
            }

            return creditModelsClass;
        }

        // PUT: api/CreditModelsClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditModelsClass(int id, CreditModelsClass creditModelsClass)
        {
            if (id != creditModelsClass.CreditID)
            {
                return BadRequest();
            }

            _context.Entry(creditModelsClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditModelsClassExists(id))
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

        // POST: api/CreditModelsClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("Cpost")]
        public async Task<ActionResult<CreditModelsClass>> PostCreditModelsClass(CreditModelsClass creditModelsClass)
        {
            _context.CreditTB.Add(creditModelsClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditModelsClass", new { id = creditModelsClass.CreditID }, creditModelsClass);
        }

        // DELETE: api/CreditModelsClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CreditModelsClass>> DeleteCreditModelsClass(int id)
        {
            var creditModelsClass = await _context.CreditTB.FindAsync(id);
            if (creditModelsClass == null)
            {
                return NotFound();
            }

            _context.CreditTB.Remove(creditModelsClass);
            await _context.SaveChangesAsync();

            return creditModelsClass;
        }

        private bool CreditModelsClassExists(int id)
        {
            return _context.CreditTB.Any(e => e.CreditID == id);
        }
    }
}
