using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
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
        public  DbSet<MainEntity>  AdminBaker { get; set; }
        public DbSet<ResgistroDetalles> RegistroDetalles { get; set; }
    }
}
