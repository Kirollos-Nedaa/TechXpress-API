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
    public class RelatedProductConfiguration : IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasKey(rp => new { rp.ProductID, rp.RelatedProductID });

            builder.HasOne(rp => rp.Product)
                .WithMany(p => p.RelatedProducts)
                .HasForeignKey(rp => rp.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.Related)
                .WithMany()
                .HasForeignKey(rp => rp.RelatedProductID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
