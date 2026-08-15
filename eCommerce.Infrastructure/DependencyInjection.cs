using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.DBContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extention method to add infrastructure services to the dependency injection container i.e IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        // Add your infrastructure services to the service container eg. data access, caching and logging services, etc. 

        services.AddSingleton<IUserRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}
