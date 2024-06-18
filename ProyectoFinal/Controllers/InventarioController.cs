using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult IndexInventario()
        {
            return View();
        }
    }
}
