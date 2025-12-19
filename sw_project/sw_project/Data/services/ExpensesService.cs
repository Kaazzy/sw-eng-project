using sw_project.Models;
using sw_project.Repositories.Interfaces;
using sw_project.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw_project.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _repository;

        public ExpensesService(IExpensesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Expense>> GetAll(string userId)
        {
            return await _repository.GetAll(userId);
        }

        public async Task<Expense> GetById(int id, string userId)
        {
            return await _repository.GetById(id, userId);
        }

        public async Task Create(Expense expense)
        {
            await _repository.Add(expense);
        }

        public async Task Update(Expense expense)
        {
            await _repository.Update(expense);
        }

        public async Task Delete(int id, string userId)
        {
            await _repository.Delete(id, userId);
        }

        public IQueryable GetChartData(string userId)
        {
            return _repository.GetChartData(userId);
        }
    }
}
