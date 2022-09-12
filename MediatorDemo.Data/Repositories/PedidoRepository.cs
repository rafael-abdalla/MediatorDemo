using MediatorDemo.Data.Context;
using MediatorDemo.Domain;
using MediatorDemo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Data.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDemoContext _context;

    public PedidoRepository(AppDemoContext context)
    {
        _context = context;
    }

    public async Task<Pedido?> BucarPorId(Guid id) =>
        await _context.Pedidos.FindAsync(id);

    public async Task<List<Pedido>> BuscarTodos() =>
        await _context.Pedidos.AsNoTracking().Include(x => x.PedidoItens).ToListAsync();

    public async Task Inserir(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }
}