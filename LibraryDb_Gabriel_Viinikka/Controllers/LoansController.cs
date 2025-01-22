using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LoansController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loans>>> GetDbLoans()
        {
            return await _context.DbLoans.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loans>> GetLoans(int id)
        {
            var loans = await _context.DbLoans.FindAsync(id);

            if (loans == null)
            {
                return NotFound();
            }

            return loans;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoans(int id, Loans loans)
        {
            if (id != loans.Id)
            {
                return BadRequest();
            }

            _context.Entry(loans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoansExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loans>> PostLoans(Loans loans)
        {
            _context.DbLoans.Add(loans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoans", new { id = loans.Id }, loans);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoans(int id)
        {
            var loans = await _context.DbLoans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }

            _context.DbLoans.Remove(loans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoansExists(int id)
        {
            return _context.DbLoans.Any(e => e.Id == id);
        }
    }
}
