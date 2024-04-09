using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
