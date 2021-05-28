using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Web
{
    public static class ConfigureVersioningExtension
    {
        public static IServiceCollection AddVersioning(
            this IServiceCollection services,
            int majorVersion,
            int minorVersion )
        {
            return services.AddApiVersioning( options =>
            {
                options.DefaultApiVersion = new ApiVersion( majorVersion, minorVersion );
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            } );
        }
    }
}
