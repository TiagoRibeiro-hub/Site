using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Games.Core.Repository;
public static class RegisteredPlayersRepositoryConfig
{
    public static void AddRegisteredPlayersRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRegisteredPlayersRead<>), typeof(RegisteredPlayersRead<>));
        services.AddScoped(typeof(IRegisteredPlayersWrite<>), typeof(RegisteredPlayersWrite<>));
        // 
        services.AddScoped<IRegisteredPlayersRepository, RegisteredPlayersRepository>();
    }
}