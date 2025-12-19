using Microsoft.AspNetCore.Mvc;
using sw_project.Models;
using sw_project.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sw_project.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        // Helper method to get logged-in user ID
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var expenses = await _expensesService.GetAll(userId);
            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expense.UserId = GetUserId();
                await _expensesService.Create(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetUserId();
            var expense = await _expensesService.GetById(id, userId);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense expense)
        {
            if (id != expense.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                expense.UserId = GetUserId();
                await _expensesService.Update(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var expense = await _expensesService.GetById(id, userId);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();
            await _expensesService.Delete(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}




