
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public class ProductoVM
    {
        public Productos Producto { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> PadreLista { get; set; }

    }
}
