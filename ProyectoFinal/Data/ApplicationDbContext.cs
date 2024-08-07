﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entities;
using ProyectoFinal.Models;
using System.Reflection;

namespace ProyectoFinal.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        // {

        //Paa cambiar el nombre de las tablas
        /*  base.OnModelCreating(builder);
          builder.HasDefaultSchema("Identity");
          builder.Entity<IdentityUser>(
              entity => {
                  entity.ToTable(name: "User");
                  }
              );

          builder.Entity<IdentityRole>(
            entity => {
                entity.ToTable(name: "Role");
            }
            );

          builder.Entity<IdentityUserRole<string>>(
            entity => {
                entity.ToTable(name: "UserRoles");
            }
            );

          builder.Entity<IdentityUserClaim<string>>(
          entity => {
              entity.ToTable(name: "UserClaim");
          }
          );

          builder.Entity<IdentityUserLogin<string>>(
          entity => {
              entity.ToTable(name: "UserLogins");
          }
          );

          builder.Entity<IdentityRoleClaim<string>>(
          entity => {
              entity.ToTable(name: "RoleClaims");
          }
          );

          builder.Entity<IdentityUserToken<string>>(
          entity => {
              entity.ToTable(name: "UserTokens");
          }
          );  */
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
        }

        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<MainEntity>  AdminBaker { get; set; }
        public DbSet<ResgistroDetalles> RegistroDetalles { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public DbSet<Cotizacion> Cotizacion { get; set; }

        public DbSet<sugerencia> Sugerencia { get; set; }
        public DbSet<BodegaProducto> BodegasProductos { get; set; }

        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<InventarioDetalle> InventarioDetalles { get; set; }
        public DbSet<KardexInventario> KardexInventarios { get; set; }

    }
}
