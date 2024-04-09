using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orden()
        {
            return View();
        }
    }
}
