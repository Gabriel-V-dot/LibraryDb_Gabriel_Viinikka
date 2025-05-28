using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions;
using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;
using Humanizer;
using LibraryDb_Gabriel_Viinikka.Services;
using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;


namespace LibraryDb_Gabriel_Viinikka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IsbnValidator _validator;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
            _validator = new IsbnValidator();
        
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
         

            List<BookDTO> bookDTO = await _context.Books.AsNoTracking()
                .Include(auth => auth.Authors)
                .Include(rating => rating.Ratings)
                .Include(inv => inv.Inventories)
                .Select(b => b.ToBookDTO())
                .ToListAsync();
            //return await _context.Books.Include(auth => auth.Authors).Select( b => b.ToBookDTO()).ToListAsync();
            return bookDTO;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Books/5
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> SearchBooks(string search)
        {
            try
            {
                search = search.ToLower();

                if (string.IsNullOrEmpty(search))
                {
                    return BadRequest("No search parameter found");
                }

                List<BookDTO> bookDtos = await _context.Books
                    .Where(book => book.Title.ToLower().Contains(search))
                    .Select(book => new BookDTO
                    {
                        Title = book.Title,
                        ISBN = book.ISBN,
                        PublicationYear = book.PublicationDate,
                        BookAuthors = book.Authors
                        .Select(author => new MinimalAuthorDTO
                        {
                            FirstName = author.FirstName,
                            LastName = author.LastName
                        }).ToList()
                    }).ToListAsync();

                //await _context.Authors
                //.Where(a => a.LastName.ToLower().Contains(search) || a.FirstName.ToLower().Contains(search))
                //.Select(a => a.ToAuthorDTO())
                //.ToListAsync();

                if (bookDtos == null || bookDtos.Count == 0)
                {
                    return NotFound();
                }

                return bookDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed in bookSearch {ex.Message}");
                return BadRequest($"Failed in BookSearch {ex.Message}");
            }
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookDTO createBookDTO)
        {
            try
            {
                string message = createBookDTO.ISBN.Length == 9 ? " If this is an old book printed before 1974 you can enter a zero before the SBN to make it compatible with ISBN" : "";
                if (!_validator.Validate(createBookDTO.ISBN)) return BadRequest("This is not a valid ISBN" + message);

                List<Author> authors = _context.Authors.Where(auth => createBookDTO.AuthorIds.Contains(auth.Id)).ToList();

                var book = createBookDTO.ToBook(authors);

                _context.Books.Add(book);
                //Need to add an put for adding the book to the authors list of books 
                await _context.SaveChangesAsync();

                List<MinimalAuthorDTO> authorsDtos = book.Authors.Select(auth => auth.ToMinimalAuthorDTO()).ToList();


                return CreatedAtAction("GetBook", new { id = book.Id }, book.ToBookDTO(authorsDtos, []));
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
               // var book = await _context.Books.FindAsync(id).Include(auth => auth.Authors);

                var book = await _context.Books.Where(book =>book.Id == id).Include(auth => auth.Authors).FirstOrDefaultAsync();
                if (book == null)
                {
                    return NotFound();
                }

                var bookDTO = new BookDTO
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationDate,
                    BookAuthors = book.Authors.Select(auth => auth.ToMinimalAuthorDTO()).ToList()
                };

                Console.WriteLine(book);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return Ok($"Book: {bookDTO.Title} \n Author: {bookDTO.BookAuthors[0].FirstName} {bookDTO.BookAuthors[0].LastName} \n with id: {id} removed succesfully");
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
