
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using SistemaInventario.AccesoDatos.Repositorio;
using System.Linq.Expressions;

namespace ProyectoFinal.Repositorio
{
    public class CotizacionRepositorio : Repositorio<Cotizacion>, ICotizacionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CotizacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void actualizar(Cotizacion cotizacion)
        {
            var bodegaBD = _db.Cotizacion.FirstOrDefault(b => b.Id == cotizacion.Id);
            if (bodegaBD != null)
            {
                bodegaBD.Nombre = cotizacion.Nombre;
                bodegaBD.Correo = cotizacion.Correo;
                bodegaBD.Tema = cotizacion.Tema;
                bodegaBD.presupuesto = cotizacion.presupuesto;
                bodegaBD.mensaje = cotizacion.mensaje;
                bodegaBD.estado = cotizacion.estado;
                _db.SaveChanges();




     
    }
        }
    }
}
