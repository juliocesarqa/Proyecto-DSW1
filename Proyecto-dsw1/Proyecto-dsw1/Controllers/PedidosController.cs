
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/pedidos")]
    public class PedidosController : CrudController<Pedido>
    {
        public PedidosController(IRepository<Pedido> repository)
            : base(repository)
        {
        }
    }
}
