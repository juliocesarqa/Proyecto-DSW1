using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_dsw1.Models
{
    public class Pago
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El pedido es obligatorio")]
        [Display(Name = "Pedido")]
        public int pedidoId { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [StringLength(30, ErrorMessage = "El método no puede superar los 30 caracteres")]
        [Display(Name = "Método de pago")]
        public string metodoPago { get; set; } 

        [StringLength(60, ErrorMessage = "El código de transacción no puede superar los 60 caracteres")]
        [Display(Name = "Código de operación")]
        public string codigoTransaccion { get; set; }

        [Required(ErrorMessage = "El monto pagado es obligatorio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Monto abonado")]
        public decimal monto { get; set; }

        [Required(ErrorMessage = "El estado del pago es obligatorio")]
        [StringLength(20, ErrorMessage = "El estado no puede superar los 20 caracteres")]
        [Display(Name = "Estado del pago")]
        public string estadoPago { get; set; } = "Completado";

        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        [Display(Name = "Fecha de pago")]
        public DateTime fechaPago { get; set; } = DateTime.Now;
    }
}
