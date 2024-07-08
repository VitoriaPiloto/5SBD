using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DataContext;
using WebApplication1.Core.Controle;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Controller
{
    public class ProdutosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public ProdutosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

        // GET: Produtos
        [HttpGet]
        [Route("/produtos")]
        public IList<Produtos> GetProdutos()
        {
            return new ControleProdutos(_context).ObterProdutos();
        }

        //POST: Produtos
        [HttpPost]
        [Route("/produtos")]
        public ActionResult PostProdutos([FromBody] ProdutosViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                var mapProduto = Mapper.Map<Produtos>(produto);
                var salvouProduto = new ControleProdutos(_context).SalvarProdutos(mapProduto);

                if (!salvouProduto)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
            }

            return Created("Produto adicionado", produto);
        }
    }
}
