using SportBox7.Domain.Models.Editors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SportBox7.Domain.Models.Articles;

using static SportBox7.Domain.Models.ModelConstants.Common;
using static SportBox7.Domain.Models.ModelConstants.Editor;
using SportBox7.Domain.Models;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    public class EditorConfigurationI : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(NamesMaxLength);

            builder.Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(NamesMaxLength);

            builder
                .HasMany(a=> a.Articles)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("articles");

        }
    }
}
