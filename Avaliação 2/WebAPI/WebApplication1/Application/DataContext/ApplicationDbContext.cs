using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Application.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pedidos> pedidos { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NEXORJ73\SQLEXPRESS;Database=AvaliacaoAV1;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }


    }
}
