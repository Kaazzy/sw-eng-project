using Microsoft.EntityFrameworkCore;
using sw_project.Models; // Import your Expense model

namespace sw_project.Data
{
    public class FinanceAppContext : DbContext
    {
        // Constructor to pass database configuration options
        public FinanceAppContext(Microsoft.EntityFrameworkCore.DbContextOptions<FinanceAppContext> options) : base(options)
        {
        }

        // DbSet: This property maps the Expense model to the 'Expenses' table in the DB
        public DbSet<Expense> Expenses { get; set; }
    }

    public class DbContextOptions<T>
    {
    }
}