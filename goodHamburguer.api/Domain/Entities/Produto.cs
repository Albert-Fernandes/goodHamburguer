using goodHamburguer.api.Domain.Enums;

namespace goodHamburguer.api.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public CategoriaProduto Categoria { get; set; }

        public Produto() { }

        public Produto(string nome, decimal preco, CategoriaProduto categoria)
        { 
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }

    }
}
