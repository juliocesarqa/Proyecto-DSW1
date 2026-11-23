
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/detallespedido")]
    public class DetallesPedidoController : CrudController<DetallePedido>
    {
        public DetallesPedidoController(
            IRepository<DetallePedido> repository)
            : base(repository)
        {
        }
    }
}
