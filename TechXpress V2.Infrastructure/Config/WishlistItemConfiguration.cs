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
    public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.HasKey(wi => wi.WishlistItemID);

            builder.Property(wi => wi.AddedAt)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(wi => wi.Wishlist)
                .WithMany(w => w.Items)
                .HasForeignKey(wi => wi.WishlistID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wi => wi.Variant)
                .WithMany(v => v.WishlistItems)
                .HasForeignKey(wi => wi.VariantID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(wi => new { wi.WishlistID, wi.VariantID })
                .IsUnique();
        }
    }
}
