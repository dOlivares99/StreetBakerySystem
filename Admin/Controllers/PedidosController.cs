using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
