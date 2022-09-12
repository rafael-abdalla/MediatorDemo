using FluentValidation.AspNetCore;
using MediatorDemo.API.Filters;
using MediatorDemo.Data.Context;
using MediatorDemo.Data.Repositories;
using MediatorDemo.Domain.Interfaces;
using MediatorDemo.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MediatorDemo.API.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddDbContext<AppDemoContext>(opt =>
            opt.UseInMemoryDatabase("AppDemoDb"));

        services.AddScoped<NotificationContext>();

        services
            .AddControllersWithViews(options =>
            options.Filters.Add<NotificationFilter>());

        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
    }
}