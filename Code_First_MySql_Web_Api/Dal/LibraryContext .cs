using Code_First_MySql_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_MySql_Web_Api.Dal
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
          : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=codefirst_blog;Uid=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(t => t.ISBN);
                entity.Property(e => e.Title);
                entity.HasOne(f => f.Publisher).WithMany(y => y.Books);
            });
        }
    }
}
