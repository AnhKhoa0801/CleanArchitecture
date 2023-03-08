using Domain.Interface;
using Infrastructure.DocumentRepository;
using Marten;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<DatabaseContext>(c =>
        //        c.UseSqlServer(configuration.GetConnectionString("Database")));

        //services.AddScoped<IProductRepository, ProductRepository>();

        services.AddMarten(options =>
        {
            options.Connection(configuration.GetConnectionString("Database")!);
        });

        services.AddScoped<IProductRepository, ProductDocRepository>();

        return services;
    }
}
