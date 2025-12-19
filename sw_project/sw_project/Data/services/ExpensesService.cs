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

        public async Task<Expense?> GetById(int id, string? userId = null)
        {
            var query = _context.Expenses.AsQueryable().Where(e => e.ID == id);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                query = query.Where(e => e.UserId == userId);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Expense expense)
        {
            var existing = await _context.Expenses.FirstOrDefaultAsync(e => e.ID == expense.ID && e.UserId == expense.UserId);
            if (existing is null) return;

            existing.Description = expense.Description;
            existing.Amount = expense.Amount;
            existing.Date = expense.Date;
            existing.Category = expense.Category;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id, string? userId = null)
        {
            var query = _context.Expenses.AsQueryable().Where(e => e.ID == id);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                query = query.Where(e => e.UserId == userId);
            }
            var entity = await query.FirstOrDefaultAsync();
            if (entity is null) return false;
            _context.Expenses.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
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
