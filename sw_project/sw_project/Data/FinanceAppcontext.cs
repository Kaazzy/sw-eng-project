using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using sw_project.Models; // Import your Expense model

namespace sw_project.Data
{
    public class FinanceAppContext : IdentityDbContext<IdentityUser>
    {
        // Constructor to pass database configuration options
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options)
        {
        }

        // DbSet: This property maps the Expense model to the 'Expenses' table in the DB
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure decimal precision for Amount
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Currency)
                .HasConversion<string>();
        }
    }
}