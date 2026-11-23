
using Microsoft.AspNetCore.Mvc;
using Proyecto_dsw1.Repositories;

namespace Proyecto_dsw1.Controllers
{
    [ApiController]
    public abstract class CrudController<T> : ControllerBase
        where T : class
    {
        protected readonly IRepository<T> _repository;

        protected CrudController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Listar()
        {
            var registros = await _repository.ListarAsync();
            return Ok(registros);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Buscar(int id)
        {
            var registro = await _repository.BuscarPorIdAsync(id);

            if (registro == null)
                return NotFound(new { mensaje = "Registro no encontrado" });

            return Ok(registro);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Registrar(
            [FromBody] T entidad)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var registro = await _repository.RegistrarAsync(entidad);

            return StatusCode(201, registro);
        }


        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Actualizar(
            int id, [FromBody] T entidad)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var existente = await _repository.BuscarPorIdAsync(id);

            if (existente == null)
            {
                return NotFound(new
                {
                    mensaje = "Registro no encontrado"
                });
            }

            var propiedadId = typeof(T).GetProperty("Id");

            if (propiedadId == null)
            {
                return BadRequest(new
                {
                    mensaje = "La entidad no tiene una propiedad Id"
                });
            }

            propiedadId.SetValue(entidad, id);

            var context = HttpContext.RequestServices
                .GetRequiredService<Proyecto_dsw1.Data.AppDbContext>();

            context.Entry(existente).CurrentValues.SetValues(entidad);

            await context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Registro actualizado correctamente"
            });
        }


        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _repository.EliminarAsync(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Registro no encontrado" });

            return Ok(new { mensaje = "Registro eliminado correctamente" });
        }
    }
}
