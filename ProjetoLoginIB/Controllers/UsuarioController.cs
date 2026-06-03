using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoginIB.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
