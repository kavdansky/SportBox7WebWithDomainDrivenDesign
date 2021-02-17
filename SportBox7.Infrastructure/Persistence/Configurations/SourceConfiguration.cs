using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportBox7.Domain.Models.Sources;
using System;
using System.Collections.Generic;
using System.Text;

using static SportBox7.Domain.Models.ModelConstants.Source;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(n => n.SourceName)
                .IsRequired()
                .HasMaxLength(SourceNameMaxLength);

            builder
                .Property(u => u.SourceUrl)
                .IsRequired();

        }
    }
}
