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
using WebApplication1.ViewModel;

namespace WebApplication1.Controller
{
    public class PedidosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IMapper _mapper;

        public PedidosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Pedidos
        [HttpGet]
        [Route("/pedidos")]
        public IEnumerable<Pedidos> GetPedidos()
        {
            return _context.pedidos.ToList();
        }

        //POST: Pedidos
        [HttpPost]
        [Route("/pedidos")]
        public ActionResult PostPedidos([FromBody]PedidosViewModel pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            // Processamento de dados
            try
            {
                var map = _mapper.Map<Pedidos>(pedido);
                _context.pedidos.Add(map); // Adiciona o objeto Pedido ao contexto
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }
            catch (Exception ex)
            {
                // Tratamento de exceção (caso haja algum erro durante o salvamento)
                return StatusCode(500, $"Erro ao salvar o pedido: {ex.Message}");
            }

            // Retorno de resultado
            return Created("Criado", pedido);
        }
    }
}
