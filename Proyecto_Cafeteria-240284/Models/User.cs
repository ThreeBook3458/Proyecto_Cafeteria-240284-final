using System.ComponentModel.DataAnnotations;

namespace Proyecto_Cafeteria_240284.Models
{
    public class User
    {
       [Required(ErrorMessage = "Falta el Usuario")]
        public string Username { get; set; }

        [Required (ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
