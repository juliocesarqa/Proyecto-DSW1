
using System.ComponentModel.DataAnnotations;

namespace Proyecto_dsw1.DTOs
{
    public class RegistrarUsuarioDto
    {
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string correo { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string clave { get; set; } = string.Empty;

        [Required]
        [StringLength(15, MinimumLength = 8)]
        public string documentoIdentidad { get; set; } = string.Empty;

        [Required]
        public DateTime fechaNacimiento { get; set; }
    }
}
