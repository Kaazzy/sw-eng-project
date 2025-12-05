using Microsoft.AspNetCore.Mvc;

namespace sw_project.Controllers
{
    public class AuthController : Controller
    {
         [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

<<<<<<< Updated upstream

        [HttpPost]

        public IActionResult Login(string email, string password)
        {
=======
        // POST: /Auth/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // For now: simple placeholder logic (no DB)
>>>>>>> Stashed changes
            if (email == "admin@example.com" && password == "123456")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password!";
            return View();
        }
    }
}
