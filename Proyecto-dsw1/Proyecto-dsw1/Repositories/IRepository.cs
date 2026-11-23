using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_dsw1.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> ListarAsync();
        Task<T?> BuscarPorIdAsync(int id);
        Task<T> RegistrarAsync(T entidad);
        Task<bool> ActualizarAsync(T entidad);
        Task<bool> EliminarAsync(int id);
    }
}
