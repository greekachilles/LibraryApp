using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryApp.Models
{
    public partial class LibraryApplicationDBContext : DbContext
    {
        public LibraryApplicationDBContext()
        {
        }

        public LibraryApplicationDBContext(DbContextOptions<LibraryApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Borrower> Borrower { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.BorrowerId)
                    .HasConstraintName("FK_Book_Borrower");
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });


            modelBuilder.Entity<Book>().HasData(
               new Book()
               {
                   BookId = 1,
                   Author = "Mary-Jane Smith",
                   Name = "My First Book",
                   Year = 2008
               },
               new Book()
               {
                   BookId = 2,
                   Author = "Mary-Jane Smith",
                   Name = "A Science Book",
                   Year = 2010
               },
               new Book()
               {
                   BookId = 3,
                   Author = "John Doe",
                   Name = "Classics Revisited",
                   Year = 2015
               }

               );


            modelBuilder.Entity<Borrower>().HasData(
                new Borrower()
                {
                    Id=1,
                    Name = "Kelly Potts",
                    Age = 15,
                    Phone = "222-333-444"
                },
                new Borrower()
                {
                    Id=2,
                    Name = "Mike Smith",
                    Age = 36,
                    Phone="444-555-666"
                }


                );
        }
    }
}
