using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Infrastructure.Web
{
    public static class AddDefaultMvcExtension
    {
        public static IMvcBuilder AddDefaultMvc( this IServiceCollection services, string addApplicationPart )
        {
            return services
                .AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 )
                .AddJsonOptions(
                    options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    } )
                .AddApplicationPart( Assembly.Load( new AssemblyName( addApplicationPart ) ) );
        }
    }
}
