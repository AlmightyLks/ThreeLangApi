using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CountryApi.Models
{
    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<FunFact> FunFacts { get; set; }

        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunFact>()
                .HasOne(f => f.Country)
                .WithMany(c => c.FunFacts);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\Project.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
