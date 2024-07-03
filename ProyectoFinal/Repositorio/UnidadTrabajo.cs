
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

        public IBodegaRepositorio Bodega { get; private set; }
        public IProductoRepositorio Producto { get; private set; }

        public ICotizacionRepositorio Cotizacion { get; private set; }

        public IUsuarioAplicacionRepositorio UsuarioAplicacion { get; private set; }

        public ISugerenciaRepositorio sugerencia { get; private set; }

        public IBodegaProductoRepositorio BodegaProducto { get; private set; }
        public IInventarioRepositorio Inventario { get; private set; }
        public IInventarioDetalleRepositorio InventarioDetalle { get; private set; }

        public IKardexInventarioRepositorio KardexInventario { get; private set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
            Cotizacion = new CotizacionRepositorio(_db);
            UsuarioAplicacion = new UsuarioAplicacionRepositorio(_db);
            sugerencia = new SugerenciaRepositorio(_db);
            BodegaProducto = new BodegaProductoRepositorio(_db);
            Inventario = new InventarioRepositorio(_db);
            InventarioDetalle = new InventarioDetalleRepositorio(_db);
            KardexInventario = new KardexInventarioRepositorio(_db);

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
