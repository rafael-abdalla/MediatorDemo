using MediatorDemo.Data.Context;
using MediatorDemo.Domain.Entities;
using MediatorDemo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDemoContext _context;

    public ProdutoRepository(AppDemoContext context)
    {
        _context = context;
    }

    public async Task<Produto?> BucarPorId(Guid id) =>
        await _context.Produtos.FindAsync(id);

    public async Task<List<Produto>> BuscarTodos() =>
        await _context.Produtos.AsNoTracking().ToListAsync();

    public async Task Inserir(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }
}
