using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_dsw1.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El pedido es obligatorio")]
        [Display(Name = "Pedido")]
        public int pedidoId { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        [Display(Name = "Producto")]
        public int productoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 100, ErrorMessage = "La cantidad debe ser entre 1 y 100 unidades")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Precio unitario de compra")]
        public decimal precioUnitario { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Subtotal")]
        public decimal subtotal { get; set; }
    }
}
