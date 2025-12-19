using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sw_project.Services.Interfaces;
using sw_project.Models;

namespace sw_project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpensesService _expensesService;

        public HomeController(ILogger<HomeController> logger, IExpensesService expensesService)
        {
            _logger = logger;
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var expenses = (await _expensesService.GetAll(userId)).ToList();

            var model = new HomeIndexViewModel
            {
                TotalExpenses = expenses.Sum(e => e.Amount),
                ThisMonthTotal = expenses
                    .Where(e => e.Date.Year == DateTime.Now.Year && e.Date.Month == DateTime.Now.Month)
                    .Sum(e => e.Amount),
                CategoriesCount = expenses
                    .Select(e => e.Category)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .Count(),
                RecentExpenses = expenses.OrderByDescending(e => e.Date).Take(5).ToList()
            };

            return View(model);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
