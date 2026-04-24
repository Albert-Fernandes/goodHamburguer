using goodHamburguer.api.Domain.Entities;
using goodHamburguer.api.Domain.Enums;

namespace goodHamburguer.api.Application.Services
{
    public class PedidoDescontoService : IPedidoDescontoService
    {
        public void CalcularAplicarDesconto(Pedido pedido)
        {
            if (pedido == null) { return; }

            bool isHamburguer = pedido.Itens.Any(i => i.Categoria.Equals(CategoriaProduto.Hamburguer));
            bool isBatata = pedido.Itens.Any(i => i.Categoria.Equals(CategoriaProduto.Fritas));
            bool isRefrigerante = pedido.Itens.Any(i => i.Categoria.Equals(CategoriaProduto.Refrigerante));

            decimal percentualDesconto = (isHamburguer, isBatata, isRefrigerante) switch
            {
                (true, true, true) => 0.20m,
                (true, false, true) => 0.15m,
                (true, true, false) => 0.10m,
                _ => 0m
            };

            decimal valorDesconto = pedido.Subtotal * percentualDesconto;

            pedido.AplicarDesconto(valorDesconto);
        }
    }
}
