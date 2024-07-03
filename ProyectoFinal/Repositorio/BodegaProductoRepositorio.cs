﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repositorio.IRepositorio;
using SistemaInventario.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repositorio
{
    public class BodegaProductoRepositorio : Repositorio<BodegaProducto>, IBodegaProductoRepositorio
    {

        private readonly ApplicationDbContext _db;

        public BodegaProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(BodegaProducto bodegaProducto)
        {
           var bodegaProductoBD = _db.BodegasProductos.FirstOrDefault(b => b.Id == bodegaProducto.Id);
            if(bodegaProductoBD != null)
            {

                bodegaProductoBD.Cantidad = bodegaProducto.Cantidad;


                _db.SaveChanges();
            }
        }

      
    }
}
