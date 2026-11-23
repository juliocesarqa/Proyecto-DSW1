
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/pagos")]
    public class PagosController : CrudController<Pago>
    {
        public PagosController(IRepository<Pago> repository)
            : base(repository)
        {
        }
    }
}
