using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Application.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
        
        public DbSet<ItensPedido> ItensPedidos { get; set; }

        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Estoque> Estoque { get; set; }

        public DbSet<ComprasEstoque> ComprasEstoque { get; set; }

        public DbSet<Atendimentos> Atendimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NEXORJ73\SQLEXPRESS;Database=AvaliacaoAV1;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }


    }
}
