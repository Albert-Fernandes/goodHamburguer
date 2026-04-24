using goodHamburguer.api.Application.Dtos;
using goodHamburguer.api.Application.Mappings;
using goodHamburguer.api.Application.Services;
using goodHamburguer.api.Domain.Entities;
using goodHamburguer.api.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goodHamburguer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPedidoDescontoService _descontoService;

        public PedidosController(AppDbContext context, IPedidoDescontoService descontoService)
        {
            _context = context;
            _descontoService = descontoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarPedidoDto dto)
        {
            try
            {
                var pedido = new Pedido();

                foreach (var produtoId in dto.ProdutosIds) 
                {
                    var produtoReal = await _context.Produtos.FindAsync(produtoId);
                    if (produtoReal == null) 
                        return NotFound(new {Erro = $"Produto não cadastrado"});

                    pedido.AdicionarItem(produtoReal);
                }

                _descontoService.CalcularAplicarDesconto(pedido);
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                var response = pedido.ToDto();
                return CreatedAtAction(nameof(Get), new { id = pedido.Id }, response);
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pedido = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (pedido == null) return NotFound(new {Erro = "Pedido não encontrado"});

            var response = pedido.ToDto();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _context.Pedidos.Include(p => p.Itens).ToListAsync();

            var response = pedidos.Select(pedido => pedido.ToDto());
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult>Put(Guid id, [FromBody] CriarPedidoDto dto)
        {
            try
            {
                var pedidoAntigo = await _context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id.Equals(id));

                if (pedidoAntigo == null) return NotFound(new { Erro = "Pedido não encontrado" });

                _context.Pedidos.Remove(pedidoAntigo);

                var pedidoNovo = new Pedido();
                foreach (var produtoId in dto.ProdutosIds)
                {
                    var produtoReal = await _context.Produtos.FindAsync(produtoId);
                    if (produtoReal == null) return NotFound(new { Erro = "Produto não encontrado" });

                    pedidoNovo.AdicionarItem(produtoReal);
                }
                _descontoService.CalcularAplicarDesconto(pedidoNovo);
                _context.Pedidos.Add(pedidoNovo);
                await _context.SaveChangesAsync();

                return Ok(pedidoNovo.ToDto());
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return NotFound(new { Erro = "Pedido não encontrado" });

            _context.Pedidos.Remove(pedido);
            return NoContent();
        }

    }
}
