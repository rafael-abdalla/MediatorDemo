namespace MediatorDemo.Domain;

public class Pedido : Entity
{
    public Pedido(Guid id, decimal precoTotal, string observacao, DateTime criacao)
    {
        Id = id;
        PrecoTotal = precoTotal;
        Observacao = observacao;
        Criacao = criacao;
    }

    public decimal PrecoTotal { get; private set; }
    public string Observacao { get; private set; }

    public virtual ICollection<PedidoItem> PedidoItens { get; set; } = null!;
}
