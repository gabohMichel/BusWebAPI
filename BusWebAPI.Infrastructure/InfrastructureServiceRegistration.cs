using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Infrastructure.Context;
using BusWebAPI.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusWebAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<AplicacionesContext>(options =>
        //  options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
        //);

        services.AddSingleton<DbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        return services;

    }
}
