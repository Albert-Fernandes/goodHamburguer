namespace goodHamburguer.api.Application.Dtos
{
    public class CriarPedidoDto
    {
        public List<Guid> ProdutosIds { get; set; } = new List<Guid>();
    }
}
