using Microsoft.AspNetCore.Mvc;

namespace SistemaDeCadastro.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
