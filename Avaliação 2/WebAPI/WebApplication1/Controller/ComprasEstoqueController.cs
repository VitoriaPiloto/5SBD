using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DataContext;
using WebApplication1.Core.Controle;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Controller
{
    public class ComprasEstoqueController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public ComprasEstoqueController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

        // GET: Compras Estoque
        [HttpGet]
        [Route("/comprasEstoque")]
        public IList<ComprasEstoque> GetPedidos()
        {
            return new ControleComprasEstoque(_context).ObterComprasEstoques();
        }

        //POST: Compras Estoque
        [HttpPost]
        [Route("/comprasEstoque")]
        public ActionResult PostPedidos([FromBody] ComprasEstoqueViewModel compraEstoque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                var controleCompraEstoque = new ControleComprasEstoque(_context);
                var controleEstoque = new ControleEstoque(_context);

                if (controleCompraEstoque.ExisteCompraPendenteParaProduto(compraEstoque.CodigoProduto))
                {
                    var estoque = controleEstoque.ObterItemEstoque(compraEstoque.CodigoProduto);
                    estoque.Quantidade = compraEstoque.Quantidade;
                    controleEstoque.AtualizarEstoque(estoque);

                    var compraEstoqueEntidade = controleCompraEstoque.ObterCompraEstoque(compraEstoque.CodigoProduto);
                    controleCompraEstoque.ApagarCompraEstoque(compraEstoqueEntidade);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o estoque: {ex.Message}");
            }

            return Created("Estoque Atualizado", compraEstoque);
        }
    }
}