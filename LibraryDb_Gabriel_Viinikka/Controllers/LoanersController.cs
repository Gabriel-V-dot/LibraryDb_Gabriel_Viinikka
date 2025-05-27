using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using System.Diagnostics;
using Humanizer;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanersController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LoanersController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Loaners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loaner>>> GetLoaners()
        {
            return await _context.Loaners.ToListAsync();
        }

        // GET: api/Loaners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loaner>> GetLoaner(int id)
        {
            var loaner = await _context.Loaners.FindAsync(id);

            if (loaner == null)
            {
                return NotFound();
            }

            return loaner;
        }

        // PUT: api/Loaners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaner(int id, Loaner loaner)
        {
            if (id != loaner.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanerExists(id))
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

        // POST: api/Loaners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loaner>> PostLoaner(CreateLoanerDTO createLoanerDTO)
        {
            try
            {
                var loaner = createLoanerDTO.ToLoaner();
                _context.Loaners.Add(loaner);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLoaner", new { id = loaner.Id }, loaner);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Loaners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaner(int id)
        {
            var loaner = await _context.Loaners.FindAsync(id);
            if (loaner == null)
            {
                return NotFound();
            }

            _context.Loaners.Remove(loaner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanerExists(int id)
        {
            return _context.Loaners.Any(e => e.Id == id);
        }
    }
}
