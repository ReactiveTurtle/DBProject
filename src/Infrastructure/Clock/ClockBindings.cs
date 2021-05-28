using Microsoft.Extensions.DependencyInjection;
using Toolkit.Clock;

namespace Infrastructure.Clock
{
    public static class ClockBindings
    {
        public static IServiceCollection AddClock( this IServiceCollection services )
        {
            return services.AddSingleton<IClock, Clock>();
        }
    }
}
