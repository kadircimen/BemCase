using Microsoft.AspNetCore.Mvc;

namespace BemCase.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return Content("OK");
        }
    }
}
