using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleEstoque : IRepositorioEstoque
    {
        private readonly ApplicationDbContext _context;

        public ControleEstoque(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estoque> ObterItensDoEstoques()
        {
            return _context.Estoque.ToList();
        }

        public Estoque ObterItemEstoque(string codigoproduto)
        {
            return _context.Estoque.FirstOrDefault(x => x.CodigoProduto == codigoproduto);
        }

        public int ObterQuantidadeProduto(string codigoProduto)
        {
            return _context.Estoque.ToList().FirstOrDefault(x => x.CodigoProduto == codigoProduto).Quantidade;
        }

        public bool SalvarEstoque(Estoque estoque)
        {
            _context.Estoque.Add(estoque);
            var retorno = _context.SaveChanges();
            return retorno == 1;
        }

        public bool AtualizarEstoque(Estoque estoque)
        {
            _context.Estoque.Update(estoque);
            var retorno = _context.SaveChanges();
            return retorno == 1;
        }
    }
}
