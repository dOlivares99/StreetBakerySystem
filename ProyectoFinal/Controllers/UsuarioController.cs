using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Repositorio.IRepositorio;
using ProyectoFinal.Services;


namespace ProyectoFinal.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsuarioController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly ApplicationDbContext _db;

        public UsuarioController(IUnidadTrabajo unidadTrabajo, ApplicationDbContext db)
        {
            _unidadTrabajo = unidadTrabajo;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return _db.Users != null ?
            View(await _db.Users.ToListAsync()) :
                       Problem("Entity set 'ApplicationDbContext.Sugerencia'  is null.");
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var usuarioLista = await _unidadTrabajo.UsuarioAplicacion.ObtenerTodos();
            var userRole = await _db.UserRoles.ToListAsync();
            var roles = await _db.Roles.ToListAsync();

            foreach (var usuario in usuarioLista)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == usuario.Id).RoleId;
                usuario.Apellidos = roles.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return Json(new { data = usuarioLista });
        }


        [HttpPost]
        public async Task<IActionResult> BloquearDesbloquear([FromBody] string id)
        {
            var usuario = await _unidadTrabajo.UsuarioAplicacion.ObtenerPrimero(u=> u.Id == id);
            if(usuario==null)
            {
                return Json(new { success = false, message = "Error de Usuario" });
            }
            if(usuario.LockoutEnd != null && usuario.LockoutEnd > DateTime.Now)
            {
                // Usuario Bloqueado
                usuario.LockoutEnd = DateTime.Now;
            }
            else
            {
                usuario.LockoutEnd = DateTime.Now.AddYears(1000);
              
            }
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Operacion Exitosa" });

        }


        [HttpPost]
        public async Task<IActionResult> BloquearDesbloquear1([FromBody] string id)
        {
            var usuario = await _unidadTrabajo.UsuarioAplicacion.ObtenerPrimero(u => u.Id == id);
            if (usuario == null)
            {
                return Json(new { success = false, message = "Error de Usuario" });
            }
           
                
                _unidadTrabajo.UsuarioAplicacion.Remover(usuario);
            
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Operacion Exitosa, usuario removido" });

        }

        #endregion


    }
}
