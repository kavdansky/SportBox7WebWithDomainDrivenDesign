﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportBox7.Data.Models;
using SportBox7.Domain.Models.Articles;
using SportBox7.Domain.Models.Editors;
using SportBox7.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SportBox7.Infrastructure.Persistence
{
    internal class SportBox7DbContext: IdentityDbContext<User>
    {
        public SportBox7DbContext(DbContextOptions<SportBox7DbContext> options)
            :base(options)
        {
        }

        public DbSet<Article> Articles { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<SocialSignal> SocialSignals { get; set; } = default!;

        public DbSet<Source> Sources { get; set; } = default!;

        public DbSet<Editor> Editors { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
