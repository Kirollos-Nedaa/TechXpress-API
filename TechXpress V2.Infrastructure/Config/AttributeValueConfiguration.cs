using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress_V2.Domain.Models;

namespace TechXpress_V2.Infrastructure.Config
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder.HasKey(v => v.ValueID);

            builder.Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.ValueHex)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.HasOne(v => v.Attribute)
                .WithMany(a => a.Values)
                .HasForeignKey(v => v.AttributeID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
