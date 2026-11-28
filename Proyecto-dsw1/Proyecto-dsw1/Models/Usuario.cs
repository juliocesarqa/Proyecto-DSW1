using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_dsw1.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
        [Display(Name = "Nombre completo")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 4 y 50 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }

        [Required(ErrorMessage = "El documento de identidad es obligatorio")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "El documento debe tener entre 8 y 15 caracteres")]
        [Display(Name = "Documento de identidad (DNI/CE)")]
        public string documentoIdentidad { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        [Display(Name = "Rol del usuario")]
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public Rol? Rol { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fecha de registro")]
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
    }
}
