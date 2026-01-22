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
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(a => a.AttributeID);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(a => a.Name).IsUnique();

            builder.HasMany(a => a.Values)
                .WithOne(v => v.Attribute)
                .HasForeignKey(v => v.AttributeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
