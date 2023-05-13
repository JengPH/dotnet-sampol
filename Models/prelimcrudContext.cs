using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JengApp.Models
{
    public partial class prelimcrudContext : DbContext
    {
        public prelimcrudContext()
        {
        }

        public prelimcrudContext(DbContextOptions<prelimcrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stockhistory> Stockhistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=prelimcrud;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("price");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("status");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock");

                entity.Property(e => e.Units)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("units");
            });

            modelBuilder.Entity<Stockhistory>(entity =>
            {
                entity.HasKey(e => e.AStockId)
                    .HasName("PRIMARY");

                entity.ToTable("stockhistory");

                entity.Property(e => e.AStockId)
                    .HasColumnType("int(11)")
                    .HasColumnName("a_Stock_ID");

                entity.Property(e => e.AddedStock)
                    .HasColumnType("int(11)")
                    .HasColumnName("added_stock");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("date");

                entity.Property(e => e.ProdId)
                    .HasColumnType("int(11)")
                    .HasColumnName("prodID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
