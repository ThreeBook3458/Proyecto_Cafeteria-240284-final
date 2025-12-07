using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cafeteria_240284.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Falta el Usuario")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }
    }
}