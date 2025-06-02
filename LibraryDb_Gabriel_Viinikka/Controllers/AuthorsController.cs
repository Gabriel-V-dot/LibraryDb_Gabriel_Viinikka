using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;
using Humanizer;
using System.Reflection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public AuthorsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            return await _context.Authors
                .Include(book => book.Books)
                    .ThenInclude(auth => auth.Authors)
                .Select(a => a.ToAuthorDTO()).ToListAsync();
        }

        //GET: api/Authors
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MinimalAuthorDTO>>> SearchAuthors(string search)
        {
            search = search.ToLower();

            if (string.IsNullOrEmpty(search))
            {
                return BadRequest("No search parameter found");
            }

            List<MinimalAuthorDTO>? authorDTOs = await _context.Authors
                .Where(a => a.LastName.ToLower().Contains(search) || a.FirstName.ToLower().Contains(search))
                .Select(a => a.ToMinimalAuthorDTO())
                .ToListAsync();

            if(authorDTOs == null || authorDTOs.Count == 0)
            {
                return NotFound();
            }

            return authorDTOs;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(CreateAuthorDTO createAuthorDTO)
        {
            if (createAuthorDTO == null)
            {
                return BadRequest();
            }

            List<Book> books = _context.Books.Where(bId => createAuthorDTO.BookId.Contains(bId.Id)).ToList();
            var author = createAuthorDTO.ToAuthor(books);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author.ToAuthorDTO());

        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            try
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                return Ok($"author with id: {id} removed succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
