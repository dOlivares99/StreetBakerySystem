using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class TransportistaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PorEntregar()
        {
            return View();
        }

        public IActionResult Cancelados()
        {
            return View();
        }

        public IActionResult Entregados()
        {
            return View();
        }
    }
}
