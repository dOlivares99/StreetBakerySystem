using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PromocionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
