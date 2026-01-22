using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_V2.Domain.Models;

namespace TechXpress_V2.Infrastructure.Config
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(v => v.VariantID);
            
            builder.Property(v => v.SKU)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(v => v.SKU).IsUnique();

            builder.Property(v => v.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(v => v.SalePrice)
                .IsRequired(false)
                .HasColumnType("decimal(18, 2)");

            builder.Property(v => v.StockQuantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(v => v.PrimaryImageURL)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasOne(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.VariantAttributes)
                .WithOne(va => va.Variant)
                .HasForeignKey(va => va.VariantID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.OrderItems)
                .WithOne(oi => oi.Variant)
                .HasForeignKey(oi => oi.VariantID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(v => v.CartItems)
                .WithOne(ci => ci.Variant)
                .HasForeignKey(ci => ci.VariantID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.WishlistItems)
                .WithOne(wi => wi.Variant)
                .HasForeignKey(wi => wi.VariantID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
