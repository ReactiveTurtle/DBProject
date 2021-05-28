using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            return services;
        }
    }
}
