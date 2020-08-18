using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ThunderBoltDBLib.Models
{
    public partial class ThunderBoltContext : DbContext
    {

        public ThunderBoltContext(DbContextOptions<ThunderBoltContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.PkCategoryId)
                    .HasName("PK_Category");

                entity.Property(e => e.PkCategoryId).HasColumnName("pkCategoryID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.PkOrderId);

                entity.Property(e => e.PkOrderId).HasColumnName("pkOrderID");

                entity.Property(e => e.FkProductId).HasColumnName("fkProductID");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShippedDate)
                    .HasColumnName("Shipped Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkProduct)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FkProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.PkProductId);

                entity.Property(e => e.PkProductId).HasColumnName("pkProductID");

                entity.Property(e => e.FkCategoryId).HasColumnName("fkCategoryID");

                entity.Property(e => e.FkSupplierId).HasColumnName("fkSupplierID");

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.ProductName).IsRequired();

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FkCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.FkSupplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FkSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Supplier");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.PkSupplierId)
                    .HasName("PK_Supplier");

                entity.Property(e => e.PkSupplierId).HasColumnName("pkSupplierID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.CompanyName).IsRequired();

                entity.Property(e => e.ContactName).IsRequired();

                entity.Property(e => e.ContactTitle).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.HomePage).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode).IsRequired();

                entity.Property(e => e.Region).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
