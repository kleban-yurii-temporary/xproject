﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XProject.Core;

namespace XProject.WebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public DbSet<DailyEquipmentLosses> DailyLosses { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}