namespace goodHamburguer.api.Application.Dtos
{
    public class PedidoResponseDto
    {
        public Guid Id { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }

        public List<string> NomeItens { get; set; } = new List<string>();
    }
}
