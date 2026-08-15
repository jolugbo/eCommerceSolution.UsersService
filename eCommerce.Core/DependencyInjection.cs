using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extention method to add infrastructure services to the dependency injection container i.e IServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        // Add your infrastructure services to the service container eg. data context, caching and logging services, etc. 
        
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
