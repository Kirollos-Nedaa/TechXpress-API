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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.CartID);

            builder.Property(c => c.UserID)
                .IsRequired(false);

            builder.Property(c => c.SessionID)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.HasIndex(c => c.UserID)
                .IsUnique()
                .HasFilter(null);

            builder.HasIndex(c => c.SessionID)
                .IsUnique()
                .HasFilter(null);

            builder.Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Cart>(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
