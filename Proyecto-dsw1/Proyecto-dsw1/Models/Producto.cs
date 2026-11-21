using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_dsw1.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        public int categoriaId { get; set; }

        [Required(ErrorMessage = "El código SKU es obligatorio")]
        [StringLength(20, ErrorMessage = "El SKU no puede superar los 20 caracteres")]
        [Display(Name = "Código SKU")]
        public string sku { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(80, ErrorMessage = "El nombre no puede superar los 80 caracteres")]
        [Display(Name = "Nombre del producto")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        [Display(Name = "Descripción y especificaciones")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.10, 99999.99, ErrorMessage = "El precio debe ser mayor a 0")]
        [Column(TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio unitario")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 10000, ErrorMessage = "El stock no puede ser negativo")]
        [Display(Name = "Stock disponible")]
        public int stock { get; set; }

        [StringLength(250, ErrorMessage = "La URL de imagen no puede superar los 250 caracteres")]
        [Display(Name = "URL de la imagen")]
        public string imagenUrl { get; set; }

        [StringLength(200, ErrorMessage = "La advertencia legal no puede superar los 200 caracteres")]
        [Display(Name = "Advertencia o restricción legal")]
        public string advertenciaLegal { get; set; }

        [Display(Name = "Producto activo")]
        public bool activo { get; set; } = true;

        [Required(ErrorMessage = "La fecha de creación es obligatoria")]
        [Display(Name = "Fecha de registro")]
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
    }
}
