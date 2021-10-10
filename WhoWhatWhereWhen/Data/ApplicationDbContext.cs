using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhoWhatWhereWhen.Areas.Identity;
using WhoWhatWhereWhen.Models;

namespace WhoWhatWhereWhen.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var StringValueConverter = new StringListToStringValueConverter();

            modelBuilder
                .Entity<Event>()
                .Property(e => e.Attending)
                .HasConversion(StringValueConverter);

        }
    }
}
