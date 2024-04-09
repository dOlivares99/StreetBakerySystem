using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CotizacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
