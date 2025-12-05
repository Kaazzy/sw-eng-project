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


        [HttpPost]

        public IActionResult Login(string email, string password)
        {
            if (email == "admin@example.com" && password == "123456")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password!";
            return View();
        }
    }
}
