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
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.DiscountID);
            
            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(d => d.Code).IsUnique();

            builder.Property(d => d.DiscountType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(d => d.StartDate)
                .IsRequired(false);

            builder.Property(d => d.EndDate)
                .IsRequired(false);

            builder.Property(d => d.MinPurchaseAmount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValue(0.00);

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
