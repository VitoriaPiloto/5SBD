using AutoMapper;
using WebApplication1.Application.DataContext;
using WebApplication1.Model;
using WebApplication1.Model.Repositorio;

namespace WebApplication1.Core.Controle
{
    public class ControleCliente : IRepositorioClientes
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public ControleCliente(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Clientes> ObterClientes()
        {
            return _context.Clientes.ToList();
        }

        public bool SalvarCliente(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            var retorno = _context.SaveChanges();
            return retorno == 1;
        }
    }
}
                              