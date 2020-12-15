using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LoanFacilityContext : DbContext
    {
        public LoanFacilityContext(DbContextOptions<LoanFacilityContext> options) : base(options)
        {  
        }
        
        public DbSet<Loan> Loans { get; set; }
        
        public DbSet<Rate> Rates { get; set; }
        public DbSet<LoanOffer> LoanOffers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}