using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleAtendimentos : IRepositorioAtendimentos
    {
        private readonly ApplicationDbContext _context;

        public ControleAtendimentos(ApplicationDbContext context)
        {
            _context = context;
        }

        public Atendimentos CriarAtendimentoDoPedido(string IdPedido)
        {
            var controleItensPedido = new ControleItensPedido(_context);
            var controleProduto = new ControleProdutos(_context);
            var controleEstoque = new ControleEstoque(_context);

            double valorTotal = 0;
            bool possuiTodosOsItens = true; 

            var itensPedido = controleItensPedido.ObterItemPedido(IdPedido);

            foreach (var itemPedido in itensPedido)
            {
                var produto = controleProduto.ObterProduto(itemPedido.IdProduto);
                var estoque = controleEstoque.ObterQuantidadeProduto(produto.Sku);

                if (estoque <= 0)
                {
                    possuiTodosOsItens = false;
                }

                valorTotal = valorTotal + (itemPedido.Quantidade * produto.Preco);
            }

            var atendimento = new Atendimentos
            {
                possuiTodosOsItens = possuiTodosOsItens ? 0 : 1,
                AtendimentosId = IdPedido,
                PrecoTotal = valorTotal
            };

            return atendimento;
        }

        public bool SalvarAtendimento(Atendimentos atendimento)
        {
            _context.Atendimentos.Add(atendimento);
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
