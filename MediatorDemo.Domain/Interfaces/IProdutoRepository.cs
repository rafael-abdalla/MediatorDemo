namespace MediatorDemo.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> BuscarTodos();
    Task<Produto?> BucarPorId(Guid id);
    Task Inserir(Produto produto);
}