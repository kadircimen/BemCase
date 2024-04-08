using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BemCase.Application.Features.User.Commands.Login;
using BemCase.Application.Features.User.Commands.Register;
using BemCase.Application.Features.User.Commands.Logout;

namespace BemCase.Web.Controllers
{
    public class AuthController : BaseController
    {

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await Mediator.Send(new LogoutUserCommand());
            return RedirectToAction("Login", "Auth");
        }
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            var result = await Mediator.Send(request);
            return Content(JsonConvert.SerializeObject(result));
        }
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            var result = await Mediator.Send(request);
            return Content(JsonConvert.SerializeObject(result));
        }
    }
}
