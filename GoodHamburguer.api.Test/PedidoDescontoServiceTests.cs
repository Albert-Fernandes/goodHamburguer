using goodHamburguer.api.Application.Services;
using goodHamburguer.api.Domain.Entities;
using goodHamburguer.api.Domain.Enums;

namespace GoodHamburguer.api.Test
{
    public class PedidoDescontoServiceTests
    {
        [Fact]
        public void CalcularEAplicarDesconto_ComboCompleto_DeveAplicar20PorcentoDeDesconto()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Produto("X-Burguer", 10.00m, CategoriaProduto.Hamburguer));
            pedido.AdicionarItem(new Produto("Fritas", 5.00m, CategoriaProduto.Fritas));
            pedido.AdicionarItem(new Produto("Coca", 5.00m, CategoriaProduto.Refrigerante));

            var descontoService = new PedidoDescontoService();

            descontoService.CalcularAplicarDesconto(pedido);

            Assert.Equal(20.00m, pedido.Subtotal);
            Assert.Equal(4.00m, pedido.ValorDesconto);
            Assert.Equal(16.00m, pedido.ValorTotal);

        }
        [Fact]
        public void CalcularEAplicarDesconto_SemCombo_NaoDeveAplicarDesconto()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Produto("Batata", 5.00m, CategoriaProduto.Fritas));
            pedido.AdicionarItem(new Produto("Coca", 5.00m, CategoriaProduto.Refrigerante));

            var descontoService = new PedidoDescontoService();
            descontoService.CalcularAplicarDesconto(pedido);

            Assert.Equal(10.00m, pedido.Subtotal);
            Assert.Equal(0m, pedido.ValorDesconto);
            Assert.Equal(10.00m, pedido.ValorTotal);


        }
    }
}
