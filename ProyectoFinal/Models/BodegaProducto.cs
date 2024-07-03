using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class BodegaProducto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BodegaId { get; set; }

        [ForeignKey("BodegaId")]
        public Bodega Bodega { get; set; }
        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Productos Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}
