using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
