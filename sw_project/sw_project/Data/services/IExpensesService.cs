using sw_project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw_project.Services.Interfaces
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll(string userId);
        Task<Expense?> GetById(int id, string userId);
        Task Create(Expense expense);
        Task Update(Expense expense);
        Task Delete(int id, string userId);
        IQueryable GetChartData(string userId);
    }
}
