using Microsoft.AspNetCore.Identity;

namespace ProyectoFinal.Models
{
    public class ApplicationUser:IdentityUser
    {
        public required string nombres { set; get; }
        public required string Apellidos { set; get; }
        public required string Direccion { set; get; }
        public required string Numero { set; get; }
        public string NumeroAdiccional { set; get; }

    }
}
