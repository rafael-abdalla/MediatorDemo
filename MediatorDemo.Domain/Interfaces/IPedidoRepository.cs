namespace MediatorDemo.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<List<Pedido>> BuscarTodos();
    Task<Pedido?> BucarPorId(Guid id);
    Task Inserir(Pedido pedido);
}