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
    public class BookInventoriesController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BookInventoriesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/BookInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookInventory>>> GetBooksInventory()
        {
            return await _context.BooksInventory.ToListAsync();
        }

        // GET: api/BookInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookInventory>> GetBookInventory(int id)
        {
            var bookInventory = await _context.BooksInventory.FindAsync(id);

            if (bookInventory == null)
            {
                return NotFound();
            }

            return bookInventory;
        }

        // PUT: api/BookInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookInventory(int id, BookInventory bookInventory)
        {
            if (id != bookInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookInventoryExists(id))
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

        // POST: api/BookInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookInventory>> PostBookInventory(BookInventory bookInventory)
        {
            _context.BooksInventory.Add(bookInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookInventory", new { id = bookInventory.Id }, bookInventory);
        }

        // DELETE: api/BookInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookInventory(int id)
        {
            var bookInventory = await _context.BooksInventory.FindAsync(id);
            if (bookInventory == null)
            {
                return NotFound();
            }

            _context.BooksInventory.Remove(bookInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookInventoryExists(int id)
        {
            return _context.BooksInventory.Any(e => e.Id == id);
        }
    }
}
