namespace MediatorDemo.API.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen();
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
