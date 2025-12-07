using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Cafeteria_240284.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, 999999.99)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string? ImagenUrl { get; set; }

        public string? ImagenBase64 { get; set; }

        [NotMapped] // No se guarda en la base de datos
        public IFormFile? ImagenArchivo { get; set; }
    }
}