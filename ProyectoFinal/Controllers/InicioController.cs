using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Especificaciones;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;

namespace ProyectoFinal.Controllers
{
    public class InicioController : Controller
    {

        private readonly ILogger<InicioController> _logger;
        private readonly IUnidadTrabajo _unidadTrabajo;


        public InicioController(ILogger<InicioController> logger, IUnidadTrabajo unidadTrabajo)
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index(int pageNumber = 1, string busqueda = "", string busquedaActual = "")
        {

            //
            if (!String.IsNullOrEmpty(busqueda))
            {
                pageNumber = 1;
            }
            else
            {
                busqueda = busquedaActual;
            }
            ViewData["BusquedaActual"] = busqueda;

            if (pageNumber < 1) { pageNumber = 1; }

            Parametros parametros = new Parametros()
            {
                PageNumber = pageNumber,
                PageSize = 6
            };

            var resultado = _unidadTrabajo.Producto.ObtenerTodosPaginado(parametros);

            if (!String.IsNullOrEmpty(busqueda))
            {
                resultado = _unidadTrabajo.Producto.ObtenerTodosPaginado(parametros, p => p.Nombre.Contains(busqueda));
            }


            ViewData["TotalPaginas"] = resultado.MetaData.TotalPages;
            ViewData["TotalRegistros"] = resultado.MetaData.TotalCount;
            ViewData["PageSize"] = resultado.MetaData.PageSize;
            ViewData["PageNumber"] = pageNumber;
            ViewData["Previo"] = "disabled";  // clase css para desactivar el boton
            ViewData["Siguiente"] = "";

            if (pageNumber > 1) { ViewData["Previo"] = ""; }
            if (resultado.MetaData.TotalPages <= pageNumber) { ViewData["Siguiente"] = "disabled"; }

            return View(resultado);
        }

        public IActionResult SugerenciaIndex()
        {
            return View();
        }

        public IActionResult Revista()
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
