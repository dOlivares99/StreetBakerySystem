using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SugerenciaIndex()
        {
            return View();
        }
        public IActionResult EncuestaIndex()
        {
            return View();
        }

        public IActionResult TerminosIndex()
        {
            return View();
        }

        public IActionResult AcercaIndex()
        {
            return View();
        }

        public IActionResult Preguntas()
        {
            return View();
        }
    }
}
