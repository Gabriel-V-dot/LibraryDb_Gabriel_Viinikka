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
using LibraryDb_Gabriel_Viinikka.DTOs.LoanDTOs;

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
        public async Task<ActionResult<LoanDTO>> GetLoans()
        {
            List<ActiveLoanDTO> activeLoanDTOs = await _context.Loans.AsNoTracking()
             .Include(loan => loan.LoanCard)
                 .ThenInclude(loanCard => loanCard.Loaner)
             .Include(loan => loan.Inventory)
                 .ThenInclude(inventory => inventory.Book)
                    .ThenInclude(book => book.Authors)
             .Where(loan => loan.ReturnDate == null)
             .Select(loan => loan.ToActiveLoanDTO())
             .ToListAsync();

            List<ReturnedLoanDTO> returnedLoanDTOs = await _context.Loans.AsNoTracking()
             .Include(loan => loan.LoanCard)
                 .ThenInclude(loanCard => loanCard.Loaner)
             .Include(loan => loan.Inventory)
                 .ThenInclude(inventory => inventory.Book)
                    .ThenInclude(book => book.Authors)
             .Where(loan => loan.ReturnDate != null)
             .Select(loan => loan.ToReturnLoanDTO())
             .ToListAsync();

            LoanDTO loans = new LoanDTO { ActiveLoanDTOs = activeLoanDTOs, ReturnedLoanDTOs = returnedLoanDTOs};

            return loans;
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
        [HttpPut]
        public async Task<IActionResult> ReturnLoan(UpdateLoanDTO updateLoanDTO)
        {
            try
            {

                Loan loan = await _context.Loans
                .Include(loan => loan.LoanCard)
                    .ThenInclude(loanCard => loanCard.Loaner)
                .Include(loan => loan.Inventory)
                    .ThenInclude(inventory => inventory.Book)
                       .ThenInclude(book => book.Authors)
                .Where(loan => loan.InventoryId == updateLoanDTO.InventoryId)
                .FirstAsync();

                if (loan == null)
                {
                    return BadRequest("There is no active loan for this book");
                }

                loan.ReturnDate = DateTime.Now;

                _context.Entry(loan).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoansExists(loan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                ReturnedLoanDTO loanReturnDTO = loan.ToReturnLoanDTO();

                string message = loanReturnDTO.DaysLeft < 0 ? $"You book is returned late with {loanReturnDTO.DaysLeft * -1} days." : "";

                return Ok($"{loan.ToReturnLoanDTO()} \n {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActiveLoanDTO>> PostLoan(CreateLoanDTO createLoanDTO)
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

                if (loanCard.ExpirationDate < DateTime.Now || loanCard.IsActive == false || loanCard.Loaner == null) return BadRequest("This Loan Card is not valid or has expired");
                if (inventory.Available == false) return NotFound("This book is not available");

                inventory.Available = false;
                Loan loan = new Loan
                {
                    LoanDate = DateTime.Now,
                    Inventory = inventory,
                    LoanCard = loanCard
                };


                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLoans", new { id = loan.Id }, loan.ToActiveLoanDTO());
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
