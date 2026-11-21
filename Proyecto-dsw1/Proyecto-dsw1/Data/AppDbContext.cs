using Microsoft.EntityFrameworkCore;
using Proyecto_dsw1.Models;

namespace Proyecto_dsw1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet <Producto>Producto { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<DireccionEnvio> DireccionEnvio { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }


    }
}
