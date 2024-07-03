using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using ProyectoFinal.Services;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductosController(ApplicationDbContext context, IUnidadTrabajo unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _unidadTrabajo = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }



        // GET: Productos
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            return _context.Productos != null ?
                        View(await _context.Productos.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,categoria,costo,precio,imagenURL")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,categoria,costo,precio,imagenURL")] Productos productos)
        {
            if (id != productos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.Id))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete1(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
    
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
            }
            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
          return (_context.Productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        public async Task<IActionResult> Upsert(int? id)
        {
            ProductoVM productoVM = new ProductoVM()
            {
                Producto = new Productos(),
                PadreLista = _unidadTrabajo.Producto.ObtenerTodosDropdownLista("Producto")
            };

            if (id == null)
            {
                // Crear nuevo Producto
          
                return View(productoVM);
            }
            else
            {
                productoVM.Producto = await _unidadTrabajo.Producto.Obtener(id.GetValueOrDefault());
                if (productoVM.Producto == null)
                {
                    return NotFound();
                }
                return View(productoVM);
            }
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductoVM productoVM)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                TempData[DS.Exitosa] = "valido!";

                if (productoVM.Producto.Id == 0)
                {
                    // Crear
                    string upload = webRootPath + DS.ImagenRuta;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    productoVM.Producto.imagenURL = fileName + extension;
                    await _unidadTrabajo.Producto.Agregar(productoVM.Producto);
                }
                else
                {
                    // Actualizar
                    var objProducto = await _unidadTrabajo.Producto.ObtenerPrimero(p => p.Id == productoVM.Producto.Id, isTracking: false);
                    if (files.Count > 0)  // Si se carga una nueva Imagen para el producto existente
                    {
                        string upload = webRootPath + DS.ImagenRuta;
                        string fileNAme = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //Borrar la imagen anterior
                        var anteriorFile = Path.Combine(upload, objProducto.imagenURL);
                        if (System.IO.File.Exists(anteriorFile))
                        {
                            System.IO.File.Delete(anteriorFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileNAme + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        productoVM.Producto.imagenURL = fileNAme + extension;
                    } // Caso contrario no se carga una nueva imagen
                    else
                    {
                        productoVM.Producto.imagenURL = objProducto.imagenURL;
                    }
                    _unidadTrabajo.Producto.actualizar(productoVM.Producto);
                }
                TempData[DS.Exitosa] = "Transaccion Exitosa!";
                await _unidadTrabajo.Guardar();
                //return View("Index");
                return RedirectToAction("IndexAdmin");

            }  // If not Valid

            TempData[DS.Exitosa] = "Transaccion No valida!";
            return View(productoVM);
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var bodegaDb = await _unidadTrabajo.Producto.Obtener(id);
            if (bodegaDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Producto" });
            }


            // Remover imagen
            string upload = _webHostEnvironment.WebRootPath + DS.ImagenRuta;
            var anteriorFile = Path.Combine(upload, bodegaDb.imagenURL);
            if (System.IO.File.Exists(anteriorFile))
            {
                System.IO.File.Delete(anteriorFile);
            }


            _unidadTrabajo.Producto.Remover(bodegaDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Producto borrada exitosamente" });
        }



        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Producto.ObtenerTodos();
            return Json(new { data = todos });
        }


        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Producto.ObtenerTodos();
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

    }
}
