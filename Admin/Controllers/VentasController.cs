using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
