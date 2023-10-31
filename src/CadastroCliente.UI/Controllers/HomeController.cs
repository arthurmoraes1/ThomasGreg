using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CadastroCliente.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var loginresult = await _usuarioService.Logar(userName, password);

            if (loginresult != null)
            {

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginresult.User),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim ("user_id", loginresult.UserId.ToString()),
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                TempData["ErroLogin"] = "Nome de usuário ou senha inválidos.";
                return RedirectToAction("Index");
            }
        }
    }
}
