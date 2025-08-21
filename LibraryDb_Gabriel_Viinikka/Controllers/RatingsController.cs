using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.RatingDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public RatingsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Ratings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetRatings()
        {
            return await _context.Ratings
                .Include(rate => rate.Book)
                .Select(rate => rate.ToRatingDTO())
                .ToListAsync();
        }

        // GET: api/Ratings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            try
            {
                var rating = await _context.Ratings.FindAsync(id);

                if (rating == null)
                {
                    return NotFound();
                }

                return rating;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Ratings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating(int id, Rating rating)
        {
            if (id != rating.Id)
            {
                return BadRequest();
            }

            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Ratings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(CreateRatingDTO ratingDTO, int bookId)
        {
            try
            {
                Book? book = await _context.Books.FindAsync(bookId);
                if (book == null) return NotFound();

                Rating rating = ratingDTO.ToRating(book);

                _context.Ratings.Add(rating);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRating", new { id = rating.Id }, ratingDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.ToString());
            }
        }

        // DELETE: api/Ratings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            try
            {
                var rating = await _context.Ratings.FindAsync(id);
                if (rating == null)
                {
                    return NotFound();
                }

                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private bool RatingExists(int id)
        {
            return _context.Ratings.Any(e => e.Id == id);
        }
    }
}
