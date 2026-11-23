
using Microsoft.EntityFrameworkCore;
using Proyecto_dsw1.Data;

namespace Proyecto_dsw1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _tabla;

        public Repository(AppDbContext context)
        {
            _context = context;
            _tabla = _context.Set<T>();
        }

        public async Task<List<T>> ListarAsync()
        {
            return await _tabla.AsNoTracking().ToListAsync();
        }

        public async Task<T?> BuscarPorIdAsync(int id)
        {
            return await _tabla.FindAsync(id);
        }

        public async Task<T> RegistrarAsync(T entidad)
        {
            await _tabla.AddAsync(entidad);
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task<bool> ActualizarAsync(T entidad)
        {
            try
            {
                _tabla.Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await _tabla.FindAsync(id);

            if (entidad == null)
                return false;

            _tabla.Remove(entidad);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

