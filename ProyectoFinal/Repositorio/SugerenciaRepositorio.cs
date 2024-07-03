
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using SistemaInventario.AccesoDatos.Repositorio;
using System.Linq.Expressions;

namespace ProyectoFinal.Repositorio
{
    public class SugerenciaRepositorio : Repositorio<sugerencia>, ISugerenciaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public SugerenciaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void actualizar(sugerencia bodega)
        {
            var bodegaBD = _db.Sugerencia.FirstOrDefault(b => b.Id == bodega.Id);
            if (bodegaBD != null)
            {
              
                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Categoria = bodega.Categoria;
                bodegaBD.Tipo = bodega.Tipo;
                bodegaBD.mensaje = bodega.mensaje;
                bodegaBD.estado = bodega.estado;
             
                _db.SaveChanges();




     
    }
        }



       

    }
}
