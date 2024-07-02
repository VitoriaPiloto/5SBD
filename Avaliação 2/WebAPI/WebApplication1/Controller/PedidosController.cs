using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using WebApplication1.DataContext;
using WebApplication1.Model;

namespace WebApplication1.Controller
{
    public class PedidosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        [HttpGet]
        [Route("/pedidos")]
        public IEnumerable<Pedidos> GetPedidos()
        {
            return _context.pedidos.ToList();
        }

    }
}
