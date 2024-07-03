using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    public class CotizacionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CotizacionsController(ApplicationDbContext context, IUnidadTrabajo unidadTrabajo)
        {
            _context = context;
            _unidadTrabajo = unidadTrabajo;
        }

        // GET: Cotizacions
        public async Task<IActionResult> Index()
        {
              return _context.Cotizacion != null ? 
                          View(await _context.Cotizacion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cotizacion'  is null.");
        }

        // GET: Cotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }
         
        // GET: Cotizacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cotizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,Tema,presupuesto,mensaje,estado")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                TempData[DS.Exitosa] = "Mensaje enviado Exitosamente, estamos revisando";
                return RedirectToAction(nameof(Create));
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            return View(cotizacion);
        }

        // POST: Cotizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,Tema,presupuesto,mensaje,estado")] Cotizacion cotizacion)
        {
            if (id != cotizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cotizacion);
        }

        // GET: Cotizacions/Delete/5
        public async Task<IActionResult> Delete1(int? id)
        {
            if (id == null || _context.Cotizacion == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacions/Delete/5
        [HttpPost, ActionName("Delete1")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed1(int id)
        {
            if (_context.Cotizacion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cotizacion'  is null.");
            }
            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion != null)
            {
                _context.Cotizacion.Remove(cotizacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
          return (_context.Cotizacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            Cotizacion producto = new Cotizacion();

            if (id == null)
            {
                // Crear una nueva Producto

                return View(producto);
            }
            // Actualizamos Producto
            producto = await _unidadTrabajo.Cotizacion.Obtener(id.GetValueOrDefault());
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Cotizacion producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.Id == 0)
                {
                    await _unidadTrabajo.Cotizacion.Agregar(producto);
                    TempData[DS.Exitosa] = "Cotizacion creada Exitosamente";
                }
                else
                {
                    _unidadTrabajo.Cotizacion.actualizar(producto);
                    TempData[DS.Exitosa] = "Cotizacion actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(IndexAdmin));
            }
            TempData[DS.Error] = "Producto Error";
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bodegaDb = await _unidadTrabajo.Cotizacion.Obtener(id);
            if (bodegaDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Cotizacion" });
            }
            _unidadTrabajo.Cotizacion.Remover(bodegaDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Cotizacion borrada exitosamente" });
        }



        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Cotizacion.ObtenerTodos();
            return Json(new { data = todos });
        }


        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Cotizacion.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            return _context.Cotizacion != null ?
                        View(await _context.Cotizacion.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
        }


    }
}
