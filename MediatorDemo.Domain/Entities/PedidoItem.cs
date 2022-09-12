namespace MediatorDemo.Domain.Entities;

public class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid CodigoProduto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Preco { get; private set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
