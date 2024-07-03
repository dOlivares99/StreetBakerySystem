using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class sugerencia
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe ser Maximo 60 Caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Categoria es requerido")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El Tipo es Requerido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El mensaje es Requerido")]
        public string mensaje { get; set; }

        public string? estado { get; set; }

    }
}
