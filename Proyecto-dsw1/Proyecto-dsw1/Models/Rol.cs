
using System.ComponentModel.DataAnnotations;

namespace Proyecto_dsw1.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [StringLength(20, ErrorMessage = "El rol no puede superar los 20 caracteres")]
        [Display(Name = "Nombre del rol")]
        public string Nombre { get; set; } 

        
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}