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
        }
    }
}
