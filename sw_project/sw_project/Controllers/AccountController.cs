using Microsoft.AspNetCore.Mvc;
using sw_project.Models;

namespace sw_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement actual authentication logic
                // For now, just log the attempt and redirect to home
                _logger.LogInformation("Login attempt for email: {Email}", model.Email);
                
                // This is a placeholder - actual authentication would go here
                TempData["Message"] = "Login functionality not yet implemented. This is a UI demonstration.";
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
