using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Repositorio;

namespace SistemaDeCadastro.Controllers
{
    public class LoginController : Controller
    {
        public readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Ops, senha inválida!!!";
                        }
                        
                    }

                    else
                    {
                        TempData["MensagemErro"] = "Ops,usuário e/ou senha inválio(s)!!!";
                    }

                }
                return View("Index");
            }
            catch (System.Exception error)
            {

                TempData["MensagemErro"] = $"Ops, Não conseguimos logar no seu usuário!!! Tente novamente, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
