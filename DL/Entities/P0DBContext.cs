using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class P0DBContext : DbContext
    {
        public P0DBContext()
        {
        }

        public P0DBContext(DbContextOptions<P0DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<VendorBranch> VendorBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventory");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__2645B050");

                entity.HasOne(d => d.Vendor)
                    .WithMany()
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__Inventory__Vendo__2739D489");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LineItem");

                entity.Property(e => e.OrdersId).HasColumnName("OrdersID");

                entity.HasOne(d => d.Orders)
                    .WithMany()
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__LineItem__Orders__29221CFB");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductsId).HasColumnName("ProductsID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__22751F6C");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("FK__Orders__Products__245D67DE");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__Orders__VendorID__236943A5");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<VendorBranch>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityState)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
