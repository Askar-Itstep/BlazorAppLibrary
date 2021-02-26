using System;
using BlazorAppLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorAppLibrary
{
    public partial class myDBContext : DbContext
    {
        public myDBContext()
        {
        }

        public myDBContext(DbContextOptions<myDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<OrderBook> OrderBooks { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=myDB;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.AuthorsId, "IX_AuthorsId");

                entity.HasIndex(e => e.GenresId, "IX_GenresId");

                entity.HasIndex(e => e.ImagesId, "IX_ImagesId");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorsId)
                    .HasConstraintName("FK_dbo.Books_dbo.Authors_AuthorsId");

                entity.HasOne(d => d.Genres)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenresId)
                    .HasConstraintName("FK_dbo.Books_dbo.Genres_GenresId");

                entity.HasOne(d => d.Images)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.ImagesId)
                    .HasConstraintName("FK_dbo.Books_dbo.Images_ImagesId");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<OrderBook>(entity =>
            {
                entity.HasIndex(e => e.BooksId, "IX_BooksId");

                entity.HasIndex(e => e.UsersId, "IX_UsersId");

                entity.HasOne(d => d.Books)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.BooksId)
                    .HasConstraintName("FK_dbo.OrderBooks_dbo.Books_BooksId");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.OrderBooks)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_dbo.OrderBooks_dbo.Users_UsersId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
