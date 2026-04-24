using goodHamburguer.api.Domain.Entities;
using goodHamburguer.api.Domain.Enums;

namespace GoodHamburguer.api.Test
{
    public class PedidoTests
    {
        [Fact]
        public void AdicionarItem_ItemDaMesmaCategoriaJaExiste_DeveLancarExcecao()
        {
            var pedido = new Pedido();
            var primeiroLanche = new Produto("X-Burger", 10.00m, CategoriaProduto.Hamburguer);
            var segundoLanche = new Produto("X-Burger", 10.00m, CategoriaProduto.Hamburguer);

            pedido.AdicionarItem(primeiroLanche);

            var excecao = Assert.Throws<InvalidOperationException>(() => pedido.AdicionarItem(segundoLanche));

            Assert.Contains("apenas um item da categoria", excecao.Message);
        }
    }
}
