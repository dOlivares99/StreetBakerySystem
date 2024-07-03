

using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public interface ICotizacionRepositorio:IRepositorio<Cotizacion>
    {
        void actualizar(Cotizacion cotizacion);
    }
}
