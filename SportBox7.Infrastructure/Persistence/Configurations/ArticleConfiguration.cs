using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportBox7.Domain.Models.Articles;
using System;
using System.Collections.Generic;
using System.Text;
using static SportBox7.Domain.Models.ModelConstants.Common;
using static SportBox7.Domain.Models.ModelConstants.Article;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        //  Category category, ArticleType articleType, DateTime targetDate

        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(b => b.Body)
                .IsRequired()
                .HasMaxLength(BodyMaxLength);

            builder
                .Property(h => h.H1Tag)
                .IsRequired()
                .HasMaxLength(H1MaxLength);

            builder
                .Property(m => m.MetaDescription)
                .IsRequired()
                .HasMaxLength(MetatagsMaxLength);

            builder
                .Property(m => m.MetaKeywords)
                .IsRequired()
                .HasMaxLength(MetatagsMaxLength);

            builder
                .Property(i => i.ImageUrl)
                .IsRequired();

            builder
                .Property(s => s.SeoUrl)
                .IsRequired();

            builder
               .HasOne(s => s.Source)
               .WithMany()
               .HasForeignKey("SourceId");

            builder
                .HasMany(s => s.SocialSignals)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("socialSignals");

            builder
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey("CategoryId");
               
        }
    }
}
