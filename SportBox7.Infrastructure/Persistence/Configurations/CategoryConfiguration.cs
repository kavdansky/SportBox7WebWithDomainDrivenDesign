using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportBox7.Domain.Models.Articles;
using System;
using System.Collections.Generic;
using System.Text;

using static SportBox7.Domain.Models.ModelConstants.Category;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(NamesMaxLength);

            builder
                .Property(c => c.CategoryNameEN)
                .IsRequired()
                .HasMaxLength(NamesMaxLength);
        }
    }
}
