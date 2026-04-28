using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStoreMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var usuario = _usuarioRepositorio.ValidarLogin(model.Email, model.Senha);

            if (usuario != null)
            {
                // Para resolver o erro CS1503, usamos o nome completo da classe Claim
                // Isso evita que o VS tente usar 'System.IO.BinaryReader' por engano.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Cargo),
                    new Claim("UsuarioId", usuario.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );

                return RedirectToAction("Index", "Game");
            }

            ViewBag.Erro = "Usuário ou senha inválidos";
            return View();
        }

        [HttpGet]
        public IActionResult CriarConta() => View();

        [HttpPost]
        public IActionResult CriarConta(CriarContaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool criado = _usuarioRepositorio.CriarUsuario(model.Email, model.Senha);

            if (!criado)
            {
                ViewBag.Erro = "Este e-mail já está cadastrado.";
                return View(model);
            }

            TempData["Sucesso"] = "Conta criada com sucesso! Faça login para continuar.";
            return RedirectToAction("Login");
        }

       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
