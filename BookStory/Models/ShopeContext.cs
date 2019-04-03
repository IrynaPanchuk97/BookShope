using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStory.Models
{
    public class ShopeContext : DbContext
    {
        public ShopeContext(DbContextOptions<ShopeContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Avtor> Avtors { get; set; }
        public DbSet<BookAvtor> BookAvtors { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAvtor>()
                .HasKey(a => new { a.IdBook, a.IdAvtor });

            modelBuilder.Entity<BookAvtor>()
                .HasOne(a => a.Avtor)
                .WithMany(b => b.BookAvtors)
                .HasForeignKey(a => a.IdAvtor);

            modelBuilder.Entity<BookAvtor>()
                .HasOne(a => a.Book)
                .WithMany(b => b.BookAvtors)
                .HasForeignKey(a => a.IdBook);

            //========================================================
            modelBuilder.Entity<UserBook>()
                .HasKey(a => new { a.IdBook, a.IdUser });

            modelBuilder.Entity<UserBook>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(a => a.IdUser);

            modelBuilder.Entity<UserBook>()
                .HasOne(a => a.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(a => a.IdBook);
        }

    }
}
