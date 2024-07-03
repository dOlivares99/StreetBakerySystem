

using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public interface IProductoRepositorio:IRepositorio<Productos>
    {
        void actualizar(Productos productos);

        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
