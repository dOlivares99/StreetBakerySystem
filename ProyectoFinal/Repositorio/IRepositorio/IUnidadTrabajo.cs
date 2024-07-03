using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable 
    {

        IBodegaRepositorio Bodega { get; }
        IProductoRepositorio Producto { get; }
        ICotizacionRepositorio Cotizacion { get; }
        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }
        ISugerenciaRepositorio sugerencia { get; }

        IBodegaProductoRepositorio BodegaProducto { get; }

        IInventarioRepositorio Inventario { get; }

        IInventarioDetalleRepositorio InventarioDetalle { get; }

        IKardexInventarioRepositorio KardexInventario { get; }

        Task Guardar();
    }
}
