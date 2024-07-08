using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleComprasEstoque : IRepositorioComprasEstoque
    {
        private readonly ApplicationDbContext _context;

        public ControleComprasEstoque(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SalvarComprasEstoque(ComprasEstoque comprasEstoque)
        {
            _context.ComprasEstoque.Add(comprasEstoque);
            var retorno = _context.SaveChanges();
            return retorno == 1;
        }

        public int ObterProximaChave()
        {
            var id = _context.Pedidos.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (id != null)
                return (Int32.Parse(id) + 1);
            return 1;
        }
    }
}
