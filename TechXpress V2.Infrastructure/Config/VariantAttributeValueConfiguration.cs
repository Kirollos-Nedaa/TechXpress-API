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
    public class VariantAttributeValueConfiguration : IEntityTypeConfiguration<VariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<VariantAttributeValue> builder)
        {
            builder.HasKey(va => new { va.VariantID, va.ValueID });

            builder.HasOne(va => va.Variant)
                .WithMany(v => v.VariantAttributes)
                .HasForeignKey(va => va.VariantID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(va => va.Value)
                .WithMany(v => v.VariantLinks)
                .HasForeignKey(va => va.ValueID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
