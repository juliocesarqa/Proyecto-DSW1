
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_dsw1.Data;
using Proyecto_dsw1.DTOs;
using Proyecto_dsw1.Models;

namespace Proyecto_dsw1.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(
            [FromBody] RegistrarUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            if (dto.fechaNacimiento.Date > DateTime.Today)
                return BadRequest(new
                {
                    mensaje = "La fecha de nacimiento no es válida"
                });

            var correo = dto.correo.Trim().ToLowerInvariant();

            bool existe = await _context.Usuarios
                .AnyAsync(u => u.correo == correo);

            if (existe)
                return Conflict(new
                {
                    mensaje = "El correo ya está registrado"
                });

            var usuario = new Usuario
            {
                nombre = dto.nombre.Trim(),
                correo = correo,
                documentoIdentidad = dto.documentoIdentidad.Trim(),
                fechaNacimiento = dto.fechaNacimiento,
                RolId = 2,
                fechaRegistro = DateTime.Now
            };

            usuario.clave = _passwordHasher.HashPassword(
                usuario, dto.clave);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return StatusCode(201, new
            {
                mensaje = "Usuario registrado correctamente",
                usuario.Id,
                usuario.nombre,
                usuario.correo,
                usuario.RolId
            });
        }
    }
}
