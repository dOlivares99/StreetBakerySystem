using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pasteles()
        {
            return View();
        }
    }
}
