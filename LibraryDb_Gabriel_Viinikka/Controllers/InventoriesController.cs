using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public InventoriesController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetInventory()
        {
            return await _context.Inventories.Include(i => i.Book).Select(i => i.InventoryToInventoryDTO(i.Book)).ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDTO>> GetInventory(int id)
        {
            var inventory = await _context.Inventories.Where(i => i.Id == id).Include(i => i.Book).FirstAsync();

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory.InventoryToInventoryDTO(inventory.Book);
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventoryDTO>> PostInventory(CreateInventoryDTO createInventoryDTO)
        {
            Book? book = await _context.Books.FindAsync(createInventoryDTO.BookId);
            if (book == null) return NotFound();

            Inventory inventory = book.BookTOInventory();

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            InventoryDTO inventoryDTO = inventory.InventoryToInventoryDTO(book);

            return CreatedAtAction("GetInventory", new { id = inventoryDTO.Id }, inventoryDTO);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
