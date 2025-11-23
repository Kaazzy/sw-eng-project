using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sw_project.Models;
using sw_project.Data;
using Microsoft.EntityFrameworkCore;

namespace sw_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FinanceAppContext _context;

        public HomeController(ILogger<HomeController> logger, FinanceAppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            decimal totalExpenses = 0;
            int expenseCount = 0;
            decimal averageExpense = 0;
            
            try
            {
                totalExpenses = await _context.Expenses.SumAsync(e => (decimal?)e.Amount) ?? 0;
                expenseCount = await _context.Expenses.CountAsync();
                averageExpense = expenseCount > 0 ? totalExpenses / expenseCount : 0;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Unable to retrieve expense data from database");
                // Use default values (0) when database is not available
            }
            
            ViewBag.TotalExpenses = totalExpenses;
            ViewBag.ExpenseCount = expenseCount;
            ViewBag.AverageExpense = averageExpense;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
