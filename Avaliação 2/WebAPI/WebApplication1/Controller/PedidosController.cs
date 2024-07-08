using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using WebApplication1.Model;
using AutoMapper;
using WebApplication1.Application.DataContext;
using WebApplication1.Core.Controle;
using WebApplication1.ViewModel;

namespace WebApplication1.Controller
{
    public class PedidosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper Mapper;

        public PedidosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }

        // GET: Pedidos
        [HttpGet]
        [Route("/pedidos")]
        public IEnumerable<Pedidos> GetPedidos()
        {
            return new ControlePedidos(_context).ObterPedidos();
        }

        //POST: Pedidos
        [HttpPost]
        [Route("/pedidos")]
        public ActionResult PostPedidos([FromBody] PedidosViewModel pedido)
        {
            var controleCliente = new ControleCliente(_context);
            var controlePedidos = new ControlePedidos(_context);
            var controleItensPedido = new ControleItensPedido(_context);
            var controleAtendimento = new ControleAtendimentos(_context);

            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                var mapPedido = Mapper.Map<Pedidos>(pedido);

                mapPedido.Id = controlePedidos.ObterProximaChave().ToString();

                var clienteExiste = controleCliente.ObterClientes().Any(x => x.Cpf == pedido.Cpf);

                if (!clienteExiste)
                {
                    var clienteNovo = new Clientes
                    {
                        Cpf = pedido.Cpf,
                        Email = string.Empty,
                        Nome = string.Empty,
                        Telefone = String.Empty
                    };

                    var adicionouNovoCliente = controleCliente.SalvarCliente(clienteNovo);

                    if (!adicionouNovoCliente)
                    {
                        throw new Exception();
                    }
                }

                var retorno = controlePedidos.SalvarPedido(mapPedido);

                if (!retorno)
                {
                    throw new Exception();
                }

                if (pedido.ItensPedidos.Count > 0)
                {
                    foreach (var itemPedido in pedido.ItensPedidos)
                    {
                        if (!new ControleProdutos(_context).ProdutoExistente(itemPedido.IdProduto))
                            throw new Exception();

                        var mapItemPedido = Mapper.Map<ItensPedido>(itemPedido);

                        mapItemPedido.Id = controleItensPedido.ObterProximaChave().ToString();
                        mapItemPedido.IdPedido = mapPedido.Id;

                        var salvouItempedido = controleItensPedido.SalvarItensPedido(mapItemPedido);

                        if (!salvouItempedido)
                        {
                            throw new Exception();
                        }
                    }
                }

                var atendimento = controleAtendimento.CriarAtendimentoDoPedido(mapPedido.Id);

                var salvouAtendimento = controleAtendimento.SalvarAtendimento(atendimento);

                if (!salvouAtendimento)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o pedido: {ex.Message}");
            }

            return Created("Criado", pedido);
        }
    }
}
