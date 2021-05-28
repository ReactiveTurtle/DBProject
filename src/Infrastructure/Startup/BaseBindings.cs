using Domain;
using Infrastructure.Clock;
using Infrastructure.Data;
using Infrastructure.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Startup
{
    public static class BaseBindings
    {
        public static IServiceCollection AddBaseServices( this IServiceCollection services, IConfiguration configuration )
        {
            return services
                .AddClock()
                .AddRepositories()
                .AddUnitOfWork()
                .AddDomain();
        }
    }
}
