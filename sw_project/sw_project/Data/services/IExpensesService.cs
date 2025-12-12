using sw_project.Models;

namespace sw_project.Data.services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll(string? userId = null);
        Task Add(Expense expense);
        IQueryable GetChartData(string? userId = null);
    }
}
