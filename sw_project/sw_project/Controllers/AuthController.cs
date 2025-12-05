using Microsoft.AspNetCore.Mvc;

namespace sw_project.Controllers
{
    public class AuthController : Controller
    {
        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
