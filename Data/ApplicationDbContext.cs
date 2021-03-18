using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StatisticsApp.Entity;

namespace StatisticsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UTM> Utms { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
    }
}