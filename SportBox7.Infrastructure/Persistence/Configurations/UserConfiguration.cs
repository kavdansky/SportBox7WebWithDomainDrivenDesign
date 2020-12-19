using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportBox7.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(e => e.Editor)
                .WithOne()
                .HasForeignKey<User>("EditorId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
