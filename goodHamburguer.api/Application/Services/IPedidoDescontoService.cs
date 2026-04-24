using goodHamburguer.api.Domain.Entities;

namespace goodHamburguer.api.Application.Services
{
    public interface IPedidoDescontoService
    {
        void CalcularAplicarDesconto(Pedido pedido);
    }
}
