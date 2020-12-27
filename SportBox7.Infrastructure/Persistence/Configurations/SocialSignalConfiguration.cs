using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportBox7.Domain.Models.Articles;
using System;
using System.Collections.Generic;
using System.Text;

using static SportBox7.Domain.Models.ModelConstants.SocialSignal;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    public class SocialSignalConfiguration : IEntityTypeConfiguration<SocialSignal>
    {
        public void Configure(EntityTypeBuilder<SocialSignal> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .Property(i => i.VisitorIp)
                .IsRequired()
                .HasMaxLength(MaxIpLength);

                
        }
    }
}
