namespace goodHamburguer.api.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; private set; }

        private readonly List<Produto> _itens = new List<Produto>();
        public IReadOnlyCollection<Produto> Itens => _itens.AsReadOnly();

        public decimal Subtotal => _itens.Sum(i => i.Preco);
        public decimal ValorDesconto { get; private set; }
        public decimal ValorTotal => Subtotal - ValorDesconto;

        public Pedido() 
        { 
            Id = Guid.NewGuid();
        }

        public void AdicionarItem (Produto novoItem)
        {
            if (novoItem == null)  throw new ArgumentNullException(nameof(novoItem));

            bool isCategoria = _itens.Any(i => i.Categoria.Equals(novoItem.Categoria));

            if (isCategoria) 
            {
                throw new InvalidOperationException($"Cada pedido pode conter apenas um item da categoria {novoItem.Categoria}");
            }
            _itens.Add(novoItem);
        }

        public void AplicarDesconto(decimal valorDesconto)
        {
            if (valorDesconto < 0) throw new ArgumentException("O Valor do desconto deve ser mais que zero");

            ValorDesconto = valorDesconto;
        }
    }
}
