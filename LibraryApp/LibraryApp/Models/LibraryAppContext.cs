using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Models
{
    public class LibraryAppContext : IdentityDbContext<IdentityUser>
    {
        public LibraryAppContext(DbContextOptions<LibraryAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Borrower> Borrower { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

          
          

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
                        .HasConstraintName("FK_Book_Borrower")
                        .OnDelete(DeleteBehavior.SetNull);
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
                   ,
                   new Book()
                   {
                       BookId = 4,
                       Author = "Melissa Meyers",
                       Name = "Radiant Shadows",
                       Year = 2012
                   },
                   new Book()
                   {
                       BookId = 5,
                       Author = "City of Sins",
                       Name = "Daniel Blake",
                       Year = 2008
                   },
                   new Book()
                   {
                       BookId = 6,
                       Author ="Patricia Cornwell",
                       Name = "Point of Origin",
                       Year = 2015
                   },
                   
                   new Book()
                   {
                       BookId = 7,
                       Author = "Rachel Caine",
                       Name = "Chill Factor",
                       Year = 2007
                   }

                   );


                modelBuilder.Entity<Borrower>().HasData(
                    new Borrower()
                    {
                        Id = 1,
                        Name = "Kelly Potts",
                        Age = 15,
                        Phone = "222-333-444"
                    },
                    new Borrower()
                    {
                        Id = 2,
                        Name = "Mike Smith",
                        Age = 36,
                        Phone = "444-555-666"
                    },
                    new Borrower()
                    {
                        Id = 3,
                        Name = "James Brooks",
                        Age = 19,
                        Phone = "123-456-789"
                    },
                    new Borrower()
                    {
                        Id = 4,
                        Name = "Jeremy Michaels",
                        Age = 23,
                        Phone = "999-888-777"
                    },
                    new Borrower()
                    {
                        Id = 5,
                        Name = "Jessica Dwyer",
                        Age = 19,
                        Phone = "455-566-677"
                    },
                    new Borrower()
                    {
                        Id = 6,
                        Name = "Marcos Pauls",
                        Age = 21,
                        Phone = "122-333-444"
                    }


                    );
            }
        }
    }

