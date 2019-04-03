﻿// <auto-generated />
using System;
using BookStory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStory.Migrations
{
    [DbContext(typeof(ShopeContext))]
    partial class ShopeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStory.Models.Avtor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAvtor")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Avtors");
                });

            modelBuilder.Entity("BookStory.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TrendPictureURL");

                    b.Property<string>("UrlDownload");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStory.Models.BookAvtor", b =>
                {
                    b.Property<int>("IdBook");

                    b.Property<int>("IdAvtor");

                    b.HasKey("IdBook", "IdAvtor");

                    b.HasIndex("IdAvtor");

                    b.ToTable("BookAvtors");
                });

            modelBuilder.Entity("BookStory.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStory.Models.UserBook", b =>
                {
                    b.Property<int>("IdBook");

                    b.Property<int>("IdUser");

                    b.HasKey("IdBook", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("UserBooks");
                });

            modelBuilder.Entity("BookStory.Models.BookAvtor", b =>
                {
                    b.HasOne("BookStory.Models.Avtor", "Avtor")
                        .WithMany("BookAvtors")
                        .HasForeignKey("IdAvtor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStory.Models.Book", "Book")
                        .WithMany("BookAvtors")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookStory.Models.UserBook", b =>
                {
                    b.HasOne("BookStory.Models.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookStory.Models.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
