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
        public DbSet<Loans> DbLoans { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }
        public DbSet<Inventory> InventoryBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();


        }




    }


 

    }