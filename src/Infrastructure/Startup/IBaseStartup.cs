using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Startup
{
    public interface IBaseStartup : IStartup
    {
        void AddServices(IServiceCollection services);
    }
}