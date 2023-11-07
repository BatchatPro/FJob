using FJOB.Infrastructure.Utils.FileUpload;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FJOB.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection RegisterInfrostructureModule(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();

        return services;
    }
}
