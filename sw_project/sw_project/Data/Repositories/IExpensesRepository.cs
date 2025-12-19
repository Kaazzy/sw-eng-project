using sw_project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw_project.Repositories.Interfaces
{
    public interface IExpensesRepository
    {
        Task<IEnumerable<Expense>> GetAll(string userId);
        Task<Expense> GetById(int id, string userId);
        Task Add(Expense expense);
        Task Update(Expense expense);
        Task Delete(int id, string userId);
        IQueryable GetChartData(string userId);
    }
}

