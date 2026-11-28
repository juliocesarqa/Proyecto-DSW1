
using Microsoft.EntityFrameworkCore;
using Proyecto_dsw1.Models;

namespace Proyecto_dsw1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<DireccionEnvio> DireccionEnvio { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Administrador" },
                new Rol { Id = 2, Nombre = "Cliente" }
            );

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.categoria)
                .WithMany()
                .HasForeignKey(p => p.categoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DireccionEnvio>()
                .HasOne(d => d.usuario)
                .WithMany()
                .HasForeignKey(d => d.usuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.usuario)
                .WithMany()
                .HasForeignKey(p => p.usuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.direccionEnvio)
                .WithMany()
                .HasForeignKey(p => p.direccionEnvioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.pedido)
                .WithMany()
                .HasForeignKey(dp => dp.pedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.producto)
                .WithMany()
                .HasForeignKey(dp => dp.productoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pago>()
                .HasOne(pg => pg.pedido)
                .WithMany()
                .HasForeignKey(pg => pg.pedidoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
