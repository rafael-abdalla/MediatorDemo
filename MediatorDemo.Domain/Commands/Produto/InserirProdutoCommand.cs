using MediatR;

namespace MediatorDemo.Domain.Commands;

public class InserirProdutoCommand : IRequest<Produto>
{
    public string? CodigoBarras { get; set; }
    public string NomeProduto { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
}