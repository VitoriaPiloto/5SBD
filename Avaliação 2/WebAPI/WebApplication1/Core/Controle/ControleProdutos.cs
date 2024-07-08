using AutoMapper;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleProdutos : IRepositorioProdutos
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public ControleProdutos(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Produtos> ObterProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produtos ObterProduto(string codigoProduto)
        {
            return _context.Produtos.FirstOrDefault(x => x.Sku == codigoProduto);
        }

        public bool SalvarProdutos(Produtos produto)
        {
            _context.Produtos.Add(produto);
            var retorno = _context.SaveChanges();
            return retorno == 1;
        }

        public bool ProdutoExistente(string codigoProduto)
        {
            return _context.Produtos.Any(x => x.Sku == codigoProduto);
        }
    }
}
