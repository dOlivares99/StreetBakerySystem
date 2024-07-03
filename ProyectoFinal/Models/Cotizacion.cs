using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Cotizacion
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe ser Maximo 60 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Correo es Requerido")]
        [MaxLength(100, ErrorMessage = "Descripcion debe ser Maximo 100 Caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Tema es requerido")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "El presupuesto es Requerido")]
        public int presupuesto { get; set; }

        [Required(ErrorMessage = "El mensaje es Requerido")]
        public string mensaje { get; set; }

    
        public string? estado { get; set; }
    }
}
