
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using SistemaInventario.AccesoDatos.Repositorio;
using System.Linq.Expressions;

namespace ProyectoFinal.Repositorio
{
    public class ProductoRepositorio : Repositorio<Productos>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void actualizar(Productos bodega)
        {
            var bodegaBD = _db.Productos.FirstOrDefault(b => b.Id == bodega.Id);
            if (bodegaBD != null)
            {
                if(bodegaBD.imagenURL !=null)
                {
                    bodegaBD.imagenURL = bodega.imagenURL;
                }
                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.categoria = bodega.categoria;
                bodegaBD.costo = bodega.costo;
                bodegaBD.precio = bodega.precio;
               bodegaBD.estado = bodega.estado;
                bodegaBD.Padre = bodega.Padre;
                _db.SaveChanges();




     
    }
        }



        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
     
        
            if (obj == "Producto")
            {
                return _db.Productos.Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }

    }
}
