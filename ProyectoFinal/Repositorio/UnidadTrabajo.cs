
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IProductoRepositorio Producto { get; private set; }
    

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Producto = new ProductoRepositorio(_db);
          
        }
      
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
