using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ControllerDeseos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
