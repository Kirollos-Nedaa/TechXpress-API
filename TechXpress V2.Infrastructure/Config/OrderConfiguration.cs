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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderID);
            
            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(o => o.OrderNumber).IsUnique();

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(o => o.DiscountAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValue(0.00);

            builder.Property(o => o.TaxAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValue(0.00);

            builder.Property(o => o.ShippingAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValue(0.00);

            builder.Property(o => o.FinalAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(o => o.CurrentStatus)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(o => o.Notes)
                .IsRequired(false);

            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.StatusHistory)
                .WithOne(h => h.Order)
                .HasForeignKey(h => h.OrderID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
