using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_dsw1.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "La dirección de envío es obligatoria")]
        [Display(Name = "Dirección de entrega")]
        public int direccionEnvioId { get; set; }

        [Required(ErrorMessage = "El código de pedido es obligatorio")]
        [StringLength(20, ErrorMessage = "El código no puede superar los 20 caracteres")]
        [Display(Name = "Número de pedido")]
        public string numeroPedido { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(0.10, 999999.99, ErrorMessage = "El monto total debe ser mayor a 0")]
        [Column(TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total a pagar")]
        public decimal total { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(25, ErrorMessage = "El estado no puede superar los 25 caracteres")]
        [Display(Name = "Estado del pedido")]
        public string estado { get; set; } = "Pendiente"; // Pendiente | Pagado | Enviado | Entregado | Cancelado

        [Required(ErrorMessage = "La aceptación de términos legales es obligatoria")]
        [Display(Name = "Aceptó declaración jurada de uso defensivo")]
        public bool aceptaTerminosLegales { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
        [Display(Name = "Fecha de compra")]
        public DateTime fechaPedido { get; set; } = DateTime.Now;
        public DireccionEnvio? direccionEnvio { get; set; }
        public Usuario? usuario { get; set; }
    }
}
