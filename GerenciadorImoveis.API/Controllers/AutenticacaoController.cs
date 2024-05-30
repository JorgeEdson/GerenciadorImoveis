using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using GerenciadorImoveis.WebApp.Interfaces;
using Refit;
using GerenciadorImoveis.Dominio.Comunicacao.Requisicoes;

namespace GerenciadorImoveis.API.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IUsuarioApi _usuarioApi;
        public AutenticacaoController()
        {
            _usuarioApi = RestService.For<IUsuarioApi>("https://localhost:7149");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string nomeUsuario, string senha)
        {
            var token = await _usuarioApi.Autenticar(new AutenticarUsuarioRequisicao
            {
                NomeUsuario = nomeUsuario,
                Senha = senha
            });

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            HttpContext.Response.Cookies.Append("token", token);

            //redirecionar para a página inicial
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
