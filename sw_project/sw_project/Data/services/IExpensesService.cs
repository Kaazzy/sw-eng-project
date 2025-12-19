using sw_project.Models;

namespace sw_project.Data.services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll(string? userId = null);
        Task<Expense?> GetById(int id, string? userId = null);
        Task Update(Expense expense);
        Task<bool> Delete(int id, string? userId = null);
        Task Add(Expense expense);
        IQueryable GetChartData(string? userId = null);
    }
}
