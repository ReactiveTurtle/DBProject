using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainBindings
    {
        public static IServiceCollection AddDomain( this IServiceCollection services )
        {
            return services;
        }
    }
}
