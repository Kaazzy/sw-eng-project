using Microsoft.AspNetCore.Mvc;

namespace sw_project.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
