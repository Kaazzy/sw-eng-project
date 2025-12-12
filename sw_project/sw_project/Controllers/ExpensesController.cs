using System.Reflection.Metadata.Ecma335;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using sw_project.Data;
using sw_project.Data.services;
using sw_project.Models;

namespace sw_project.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

    
        public async Task<IActionResult> Index()
        {
            var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var expenses = await _expensesService.GetAll(userId);
            return View(expenses);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (!ModelState.IsValid)
                return View(expense);
            var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            expense.UserId = userId;
            await _expensesService.Add(expense);

            return RedirectToAction("Index");
        }
        
        // Returns aggregated totals per category for charting
        [HttpGet]
        public IActionResult GetChart()
        {
            var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var data = _expensesService.GetChartData(userId);

            if (data is System.Linq.IQueryable queryable)
            {
                var objects = queryable.Cast<object>().ToList();
                var list = objects.Select(x => new
                {
                    Category = x.GetType().GetProperty("Category")?.GetValue(x, null)?.ToString() ?? "(Uncategorized)",
                    Total = Convert.ToDecimal(x.GetType().GetProperty("Total")?.GetValue(x, null) ?? 0)
                }).ToList();

                return Json(list);
            }

            return Json(new object[0]);
        }
        
    }
}




