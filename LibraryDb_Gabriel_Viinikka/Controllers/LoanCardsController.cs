using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using Microsoft.IdentityModel.Abstractions;
using Humanizer;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;
using System.Diagnostics;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanCardsController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LoanCardsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanCard>>> GetLoanCards()
        {
            return await _context.LoanCards.ToListAsync();
        }

        // GET: api/LoanCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanCard>> GetLoanCard(int id)
        {
            var loanCard = await _context.LoanCards.FindAsync(id);

            if (loanCard == null)
            {
                return NotFound();
            }

            return loanCard;
        }

        // PUT: api/LoanCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanCard(int id, LoanCard loanCard)
        {
            if (id != loanCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanCardExists(id))
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

        // POST: api/LoanCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanCard>> PostLoanCard(CreateLoanCardDTO createLoanCard)
        {
            try
            {
                Loaner? loaner = await _context.Loaners.FindAsync(createLoanCard.LoanerId);
                if (loaner == null) return NotFound();

                LoanCard loanCard = loaner.LoanerToLoanCard();

                _context.LoanCards.Add(loanCard);
                await _context.SaveChangesAsync();

                LoanCardDTO loanCardDTO = loanCard.LoanCardToLoanCardDTO();

                return CreatedAtAction("GetLoanCard", new { id = loanCardDTO.Id }, loanCardDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/LoanCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanCard(int id)
        {
            try
            {
                var loanCard = await _context.LoanCards.Where(lc => lc.Id == id).Include(lc => lc.Loaner).FirstAsync();
                if (loanCard == null)
                {
                    return NotFound();
                }

                LoanCardDTO loanCardDTO = loanCard.LoanCardToLoanCardDTO();

                _context.LoanCards.Remove(loanCard);
                await _context.SaveChangesAsync();

                return Ok($"Loancard: \n id: {loanCardDTO.Id}\n Name: {loanCardDTO.Loaner.FirstName}\n LastName: {loanCardDTO.Loaner.LastName} \n\nwas succesfully removed");
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                return BadRequest(ex.Message +"\n"+ ex.StackTrace);
            }
        }

        private bool LoanCardExists(int id)
        {
            return _context.LoanCards.Any(e => e.Id == id);
        }
    }
}
