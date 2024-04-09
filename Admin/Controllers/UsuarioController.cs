using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
