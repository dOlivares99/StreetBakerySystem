
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
                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.categoria = bodega.categoria;
                bodegaBD.costo = bodega.costo;
                bodegaBD.precio = bodega.precio;
                bodegaBD.imagenURL = bodega.imagenURL;
                _db.SaveChanges();




     
    }
        }
    }
}
