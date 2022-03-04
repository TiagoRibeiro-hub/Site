using Data.Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Infrastructure.Config;

public static class ServicesConfig
{
    public static void AddValidationErrorService(this IServiceCollection services)
    {
        services.AddScoped<IValidationErrorService, ValidationError>();
    }
}
