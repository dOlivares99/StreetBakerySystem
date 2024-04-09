using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
