using MediatR;

namespace MediatorDemo.Domain.Commands;

public class InserirPedidoCommand : IRequest<Guid>
{
    public InserirPedidoCommand(decimal precoTotal, string observacao)
    {
        PrecoTotal = precoTotal;
        Observacao = observacao;
    }

    public decimal PrecoTotal { get; set; }
    public string Observacao { get; set; }
}
