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
            modelBuilder.Entity<FinancialToIndustry>().HasKey(x => new { x.UtmId, x.IndustryFinancialId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UTM> Utms { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<IndustryFinancial> IndustryFinancials { get; set; }

        public DbSet<FinancialToIndustry> financialToIndustries { get; set; }


    }
}