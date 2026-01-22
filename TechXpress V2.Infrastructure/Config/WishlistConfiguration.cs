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
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(w => w.WishlistID);

            builder.HasOne(w => w.User)
                .WithOne()
                .HasForeignKey<Wishlist>(w => w.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(w => w.UserID).IsUnique();

            builder.HasMany(w => w.Items)
                .WithOne(wi => wi.Wishlist)
                .HasForeignKey(wi => wi.WishlistID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
