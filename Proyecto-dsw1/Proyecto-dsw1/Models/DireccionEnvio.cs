using System.ComponentModel.DataAnnotations;

namespace Proyecto_dsw1.Models
{
    public class DireccionEnvio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(120, ErrorMessage = "La dirección no puede superar los 120 caracteres")]
        [Display(Name = "Dirección exacta")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "La ciudad o distrito es obligatorio")]
        [StringLength(50, ErrorMessage = "La ciudad no puede superar los 50 caracteres")]
        [Display(Name = "Ciudad / Distrito")]
        public string ciudad { get; set; }

        [StringLength(100, ErrorMessage = "La referencia no puede superar los 100 caracteres")]
        [Display(Name = "Referencia")]
        public string referencia { get; set; }

        [Required(ErrorMessage = "El teléfono de contacto es obligatorio")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Teléfono inválido")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        [Display(Name = "Teléfono de contacto")]
        public string telefono { get; set; }
    }
}
