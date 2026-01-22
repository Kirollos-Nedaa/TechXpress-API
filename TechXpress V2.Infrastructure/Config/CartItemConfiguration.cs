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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.CartItemID);

            builder.Property(ci => ci.Quantity)
                .HasDefaultValue(1);

            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Variant)
                .WithMany()
                .HasForeignKey(ci => ci.VariantID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ci => new { ci.CartID, ci.VariantID })
                .IsUnique();
        }
    }
}
