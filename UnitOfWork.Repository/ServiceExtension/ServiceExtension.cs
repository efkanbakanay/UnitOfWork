using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.Domain.Interfaces;
using UnitOfWork.Infrastructure.Repositories;


namespace UnitOfWork.Infrastructure.ServiceExtension;

public static class ServiceExtension
{
    public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IUnitOfWork, Repositories.UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}