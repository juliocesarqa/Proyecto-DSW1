
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Models;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [Route("api/direccionesenvio")]
    public class DireccionesEnvioController
        : CrudController<DireccionEnvio>
    {
        public DireccionesEnvioController(
            IRepository<DireccionEnvio> repository)
            : base(repository)
        {
        }
    }
}
