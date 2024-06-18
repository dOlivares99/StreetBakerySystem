using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Productos
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe ser Maximo 60 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es Requerido")]
        [MaxLength(100, ErrorMessage = "Descripcion debe ser Maximo 100 Caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La categoria es requerida")]
        public string categoria { get; set; }

        [Required(ErrorMessage = "El costo es Requerido")]
        public int costo { get; set; }

        [Required(ErrorMessage = "El precio es Requerido")]
        public int precio { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        public string imagenURL { get; set; }

        
    }
}
