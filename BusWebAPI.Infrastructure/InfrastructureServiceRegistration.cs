using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Infrastructure.Context1;
using BusWebAPI.Infrastructure.DbContexts;
using BusWebAPI.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusWebAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BusDBContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("BusDB"))
        );

        //services.AddSingleton<DbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        return services;

    }
}
