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
    public class UserPaymentMethodConfiguration : IEntityTypeConfiguration<UserPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<UserPaymentMethod> builder)
        {
            builder.HasKey(p => p.PaymentMethodID);

            builder.Property(p => p.ProviderToken)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.LastFourDigits)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(p => p.CardType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ExpiryDate)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(p => p.IsDefault)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
