namespace MediatorDemo.Domain.Commands;

public class InserirPedidoItemCommand
{
    public Guid CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
