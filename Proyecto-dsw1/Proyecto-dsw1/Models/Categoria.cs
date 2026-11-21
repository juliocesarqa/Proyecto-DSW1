using System.ComponentModel.DataAnnotations;

namespace Proyecto_dsw1.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres")]
        [Display(Name = "Nombre de categoría")]
        public string nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Requiere validación de mayoría de edad")]
        public bool requiereMayoriaEdad { get; set; } = true;
    }
}
