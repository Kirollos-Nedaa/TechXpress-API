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
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(p => p.PostID);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasIndex(p => p.Slug).IsUnique();

            builder.Property(p => p.Content)
                .IsRequired();

            builder.Property(p => p.FeaturedImageUrl)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(p => p.PublishedAt)
                .IsRequired(false);

            builder.Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .ValueGeneratedOnUpdate();

            builder.HasOne(p => p.Author)
                .WithMany(p => p.BlogPosts)
                .HasForeignKey(p => p.AuthorUserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
