using AutoMapper;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControlePedidos : IRepositorioPedidos
    {
        private readonly ApplicationDbContext _context;

        public ControlePedidos(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pedidos> ObterPedidos()
        {
            return _context.Pedidos.ToList();
        }

        public bool SalvarPedido(Pedidos pedido)
        {
            _context.Pedidos.Add(pedido);
            var retorno =_context.SaveChanges();
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
