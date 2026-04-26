using goodHamburguer.api.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace goodHamburguer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardapioController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CardapioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> ObterCardapio()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return Ok(produtos);
        }
        public ActionResult Index()
        {
            return null;
        }


    }
}
