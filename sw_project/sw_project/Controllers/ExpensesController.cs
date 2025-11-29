using System.Reflection.Metadata.Ecma335;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (!ModelState.IsValid)
                return View(expense);

            await _expensesService.Add(expense);

            return RedirectToAction("Index");
        }

        
    }
}




