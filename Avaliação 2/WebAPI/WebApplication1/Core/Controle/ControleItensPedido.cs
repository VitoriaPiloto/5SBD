using AutoMapper;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleItensPedido : IRepositorioItensPedido
    {
        private readonly ApplicationDbContext _context;

        public ControleItensPedido(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ItensPedido> ObterItensPedidos()
        {
            return _context.ItensPedidos.ToList();
        }

        public bool SalvarItensPedido(ItensPedido itemPedido)
        {
            var controleEstoque = new ControleEstoque(_context);
            var controleComprasEstoque = new ControleComprasEstoque(_context);

            _context.ItensPedidos.Add(itemPedido);
            var retorno = _context.SaveChanges();
            if (retorno == 1)
            {
                var quantidadeEstoque = controleEstoque.ObterQuantidadeProduto(itemPedido.IdProduto);

                if (quantidadeEstoque >= itemPedido.Quantidade)
                {
                    var estoqueParaAtualizar = controleEstoque.ObterItemEstoque(itemPedido.IdProduto);
                    estoqueParaAtualizar.Quantidade = quantidadeEstoque - itemPedido.Quantidade;
                    controleEstoque.AtualizarEstoque(estoqueParaAtualizar);
                }
                else if (quantidadeEstoque == 0)
                {
                    var compraEstoque = new ComprasEstoque
                    {
                        Id = controleComprasEstoque.ObterProximaChave().ToString(),
                        CodigoProduto = itemPedido.IdProduto,
                        Quantidade = itemPedido.Quantidade
                    };

                    controleComprasEstoque.SalvarComprasEstoque(compraEstoque);
                }
            }
            return retorno == 1;
        }

        public int ObterProximaChave()
        {
            var id = _context.Pedidos.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (id != null)
                return (Int32.Parse(id) + 1);
            return 1;
        }

        public IList<ItensPedido> ObterItemPedido(string codigoPedido)
        {
            return _context.ItensPedidos.Where(x => x.IdPedido == codigoPedido).ToList();
        }
    }
}
