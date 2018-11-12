﻿// <auto-generated />
using System;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApp.Migrations
{
    [DbContext(typeof(LibraryAppContext))]
    [Migration("20181109213643_dbbookscreate")]
    partial class dbbookscreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryApp.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("BorrowerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Year");

                    b.HasKey("BookId");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryApp.Models.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("LibraryApp.Models.Book", b =>
                {
                    b.HasOne("LibraryApp.Models.Borrower", "Borrower")
                        .WithMany("Book")
                        .HasForeignKey("BorrowerId")
                        .HasConstraintName("FK_Book_Borrower");
                });
#pragma warning restore 612, 618
        }
    }
}
