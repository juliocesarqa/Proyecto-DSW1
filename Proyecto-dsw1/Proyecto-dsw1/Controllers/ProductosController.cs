
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/productos")]
    public class ProductosController : CrudController<Producto>
    {
        public ProductosController(IRepository<Producto> repository)
            : base(repository)
        {
        }
    }
}
