﻿using Microsoft.EntityFrameworkCore;

namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        #region DbSet
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loaner> Loaners { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Author
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .HasColumnType("nvarchar(60)")
                .HasMaxLength(60);

            modelBuilder.Entity<Author>()
                .Property(a => a.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            #endregion

            #region Book
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .HasColumnType("nvarchar(13)")
                .HasMaxLength(13);

            modelBuilder.Entity<Book>()
                .ToTable(b => b.HasCheckConstraint("CK_Book_ISBN_Length", "LEN(ISBN) IN (10,13)"));

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Ratings)
                .WithOne(r => r.Book);

            #endregion

            #region Inventory

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Book)
                .WithMany(b => b.Inventories)
                .HasForeignKey(i => i.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inventory>()
                .ToTable(inv => inv.HasCheckConstraint("CK_Inventory_DaysToLoan", "[DaysToLoan] BETWEEN 1 AND 60"));

            #endregion

            #region Loaner

            modelBuilder.Entity<Loaner>()
                .Property(l => l.FirstName)
                .HasColumnType("nvarchar(60)")
                .HasMaxLength(60);

            modelBuilder.Entity<Loaner>()
                .Property(l => l.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            #endregion

            #region LoanCard

            modelBuilder.Entity<LoanCard>()
                .HasOne(l => l.Loaner)
                .WithMany(lc => lc.LoanCards)
                .HasForeignKey(l => l.LoanerId)
                .OnDelete(DeleteBehavior.SetNull);
            
            #endregion


            #region Rating
            modelBuilder.Entity<Rating>()
                .ToTable(s => s.HasCheckConstraint("CK_Rating_ScoreRange", "[Score] BETWEEN 1 AND 5"));

            modelBuilder
                .Entity<Rating>()
                .Property(c => c.Comment)
                .HasColumnType("nvarchar(256)")
                .HasMaxLength(256);

            #endregion

        }




    }


 

    }