using Microsoft.EntityFrameworkCore;

namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loaner> Loaners { get; set; }
        public DbSet<BookInventory> BooksInventory { get; set; }
        public DbSet<Loans> DbLoans { get; set; }

    }

}