
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/categorias")]
    public class CategoriasController : CrudController<Categoria>
    {
        public CategoriasController(IRepository<Categoria> repository)
            : base(repository)
        {
        }
    }
}
