using Microsoft.EntityFrameworkCore;
using sw_project.Data;
using sw_project.Models;
using sw_project.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw_project.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly FinanceAppContext _context;

        public ExpensesRepository(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAll(string userId)
        {
            return await _context.Expenses
                                 .Where(e => e.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Expense?> GetById(int id, string userId)
        {
            return await _context.Expenses
                                 .FirstOrDefaultAsync(e => e.ID == id && e.UserId == userId);
        }

        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id, string userId)
        {
            var expense = await GetById(id, userId);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable GetChartData(string userId)
        {
            return _context.Expenses
                           .Where(e => e.UserId == userId)
                           .GroupBy(e => e.Category)
                           .Select(g => new
                           {
                               Category = g.Key,
                               Total = g.Sum(e => e.Amount)
                           });
        }
    }
}
