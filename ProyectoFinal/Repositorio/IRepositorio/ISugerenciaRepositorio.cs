


using ProyectoFinal.Models;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public interface ISugerenciaRepositorio:IRepositorio<sugerencia>
    {
        void actualizar(sugerencia sugerencia);
    }
}
