
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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemID);

            builder.Property(oi => oi.PriceAtTimeOfPurchase)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(oi => oi.Quantity)
                .IsRequired()
                .HasDefaultValue(1);
            
            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Variant)
                .WithMany()
                .HasForeignKey(oi => oi.VariantID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
