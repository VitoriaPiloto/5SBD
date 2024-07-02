using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pedidos> pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NEXORJ73\SQLEXPRESS;Database=AvaliacaoAV1;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }


    }
}
