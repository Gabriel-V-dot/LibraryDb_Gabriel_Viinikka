using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;

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
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            return await _context.Loans.AsNoTracking()
             .Include(loan => loan.LoanCard)
                 .ThenInclude(loanCard => loanCard.Loaner)
             .Include(loan => loan.InventoryBook)
                 .ThenInclude(inventory => inventory.Book)
             .Select(loan => loan.ToLoanDTO())
             .ToListAsync();

        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loans = await _context.Loans.FindAsync(id);

            if (loans == null)
            {
                return NotFound();
            }

            return loans;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loans)
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
        public async Task<ActionResult<Loan>> PostLoan(CreateLoanDTO createLoanDTO)
        {
            try
            {
                Inventory inventory = await _context.Inventories.
                    Include(inv => inv.Book)
                    .Where(inv => inv.Id == createLoanDTO.InventoryId)
                    .FirstAsync();

                LoanCard loanCard = await _context.LoanCards
                    .Include(lc => lc.Loaner)
                    .Where(lc => lc.Id == createLoanDTO.LoanCardId)
                    .FirstAsync();

                Loan loan = new Loan
                {
                    LoanDate = DateTime.Now,
                    InventoryBook = inventory,
                    LoanCard = loanCard
                };


                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLoans", new { id = loan.Id }, loan.ToLoanDTO());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoans(int id)
        {
            var loans = await _context.Loans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoansExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
