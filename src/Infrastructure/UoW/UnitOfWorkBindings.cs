using Microsoft.Extensions.DependencyInjection;
using Toolkit.Domain.Abstractions;

namespace Infrastructure.UoW
{
    public static class UnitOfWorkBindings
    {
        public static IServiceCollection AddUnitOfWork( this IServiceCollection services )
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
