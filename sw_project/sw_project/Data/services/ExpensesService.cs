using Microsoft.EntityFrameworkCore;
using sw_project.Models;

namespace sw_project.Data.services
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;

        public ExpensesService(FinanceAppContext context) 
        {
            _context = context;
        }
        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Expense>> GetAll(string? userId = null)
        {
            var query = _context.Expenses.AsQueryable();
            if (!string.IsNullOrWhiteSpace(userId))
            {
                query = query.Where(e => e.UserId == userId);
            }
            var expenses = await query.ToListAsync();
            return expenses;
        }
        public IQueryable GetChartData(string? userId = null){
            var query = _context.Expenses.AsQueryable();
            if (!string.IsNullOrWhiteSpace(userId))
            {
                query = query.Where(e => e.UserId == userId);
            }
            var data = query
                        .GroupBy(e => e.Category)
                        .Select(g => new {
                            Category = g.Key,
                            Total = g.Sum(e => e.Amount)
                        });
            return data;
        }
    }

}
