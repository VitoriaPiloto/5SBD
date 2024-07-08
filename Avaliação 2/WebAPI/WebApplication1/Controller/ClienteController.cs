using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DataContext;
using WebApplication1.Core.Controle;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Controller
{
    public class ClienteController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public ClienteController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

        // GET: Clientes
        [HttpGet]
        [Route("/clientes")]
        public IList<Clientes> GetClientes()
        {
            return new ControleCliente(_context).ObterClientes();
        }

        //POST: Clientes
        [HttpPost]
        [Route("/clientes")]
        public ActionResult PostClientes([FromBody] ClientesViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                var mapCliente = Mapper.Map<Clientes>(cliente);
                var salvouCliente = new ControleCliente(_context).SalvarCliente(mapCliente);

                if (!salvouCliente)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar cliente: {ex.Message}");
            }

            return Created("Cliente adicionado", cliente);
        }
    }
}
