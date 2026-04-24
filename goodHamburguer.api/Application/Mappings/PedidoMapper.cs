using goodHamburguer.api.Application.Dtos;
using goodHamburguer.api.Domain.Entities;

namespace goodHamburguer.api.Application.Mappings
{
    public static class PedidoMapper
    {
        public static PedidoResponseDto ToDto(this Pedido pedido)
        {
            if (pedido == null) return null;

            return new PedidoResponseDto
            {
                Id = pedido.Id,
                Subtotal = pedido.Subtotal,
                ValorDesconto = pedido.ValorDesconto,
                ValorTotal = pedido.ValorTotal,
                NomeItens = pedido.Itens.Select(i => i.Nome).ToList(),
            };
        }
    }
}
