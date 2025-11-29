using System.Collections.Generic;
using sw_project.Models;

namespace sw_project.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Expense> RecentExpenses { get; set; } = new List<Expense>();
        public decimal TotalExpenses { get; set; }
        public decimal ThisMonthTotal { get; set; }
        public int CategoriesCount { get; set; }
    }
}
