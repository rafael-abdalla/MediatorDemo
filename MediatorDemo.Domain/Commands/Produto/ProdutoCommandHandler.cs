using MediatorDemo.Domain.Interfaces;
using MediatorDemo.Domain.Notifications;
using MediatR;

namespace MediatorDemo.Domain.Commands;

public class ProdutoCommandHandler : IRequestHandler<InserirProdutoCommand, Produto>
{
    private readonly IProdutoRepository _repository;
    private readonly NotificationContext _notifications;

    public ProdutoCommandHandler(IProdutoRepository repository, NotificationContext notifications)
    {
        _repository = repository;
        _notifications = notifications;
    }

    public Task<Produto> Handle(InserirProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto(Guid.NewGuid(), request.CodigoBarras, request.NomeProduto, request.Preco, DateTime.Now);

        if (produto.Invalid)
        {
            _notifications.AddNotifications(produto.ValidationResult);
            return Task.FromResult(produto);
        }

        if (produto.Preco > 1000)
            _notifications.AddNotification("Preco", "O preço não pode ser maio que R$ 1000,00");

        _repository.Inserir(produto);
        return Task.FromResult(produto);
    }
}