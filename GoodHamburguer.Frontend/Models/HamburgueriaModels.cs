namespace GoodHamburguer.Frontend.Models
{
    public class HamburgueriaModels
    {
        public class ProdutoModel
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Categoria { get; set; }
        }

        public class CriarPedidoRequest
        {
            public List<Guid> ProdutosIds { get; set; } = new List<Guid>();
        }

        public class PedidoResponseModel
        {
            public Guid Id { get; set; }
            public decimal SubTotal { get; set; }
            public decimal ValorDesconto { get; set; }
            public decimal Valortotal { get; set; }
            public List<string> NomeItens { get; set; } = new();
        }

        public class ErroResponse
        {
            public string Erro { get; set; }
        }
    }
}
