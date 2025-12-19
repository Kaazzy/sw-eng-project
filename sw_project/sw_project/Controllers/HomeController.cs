using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sw_project.Models;
using sw_project.Services.Interfaces;

namespace sw_project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpensesService _expensesService;

        public HomeController(
            ILogger<HomeController> logger,
            IExpensesService expensesService)
        {
            _logger = logger;
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var expenses = (await _expensesService.GetAll(userId)).ToList();

            var model = new HomeIndexViewModel();

            model.TotalExpenses = expenses.Sum(e => e.Amount);

            var now = DateTime.Now;
            model.ThisMonthTotal = expenses
                .Where(e => e.Date.Year == now.Year && e.Date.Month == now.Month)
                .Sum(e => e.Amount);

            model.CategoriesCount = expenses
                .Select(e => e.Category)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .Count();

            model.RecentExpenses = expenses
                .OrderByDescending(e => e.Date)
                .Take(5)
                .ToList();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
