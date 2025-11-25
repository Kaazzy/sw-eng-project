using sw_project.Models;

namespace sw_project.Data.services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        IQueryAble GetChartData();
    }
}
