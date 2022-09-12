using MediatorDemo.Domain;
using MediatorDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.Data.Context;

public class AppDemoContext : DbContext
{
	public AppDemoContext(DbContextOptions<AppDemoContext> options)
		: base(options) { }

	public DbSet<Produto> Produtos { get; set; } = null!;
	public DbSet<Pedido> Pedidos { get; set; } = null!;
    public DbSet<PedidoItem> PedidosItens { get; set; } = null!;
}
