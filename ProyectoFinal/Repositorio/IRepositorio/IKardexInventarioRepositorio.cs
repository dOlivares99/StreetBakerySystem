﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorio.IRepositorio
{
    public interface IKardexInventarioRepositorio : IRepositorio<KardexInventario>
    {

        Task RegistrarKardex(int bodegaProductoId, string tipo, string detalle, int stockAnterior, int cantidad, string usuarioId);

    }
}
