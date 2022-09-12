using MediatR;

namespace MediatorDemo.Domain.Commands.Pedido;

public class PedidoCommandHandler : IRequestHandler<InserirPedidoCommand, Guid>
{
    public Task<Guid> Handle(InserirPedidoCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.NewGuid());
    }
}