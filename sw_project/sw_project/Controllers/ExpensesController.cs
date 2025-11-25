using Microsoft.AspNetCore.Mvc;
using sw_project.Data;
using sw_project.Data.services;
using sw_project.Models;

namespace sw_project.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
       public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);

                return RedirectToAction("Index");
            }

            return View(expense);
        }
    }
    public IActionResult GetChart(){
        var data = _expensesServices.GetChartData();
        return json(data);
    }
}




