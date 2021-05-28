using System;
using System.Linq;
using Application;
using Infrastructure.Data;
using Infrastructure.Startup;
using Infrastructure.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api
{
    public class Startup : IBaseStartup
    {
        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup( IConfiguration configuration, IHostingEnvironment env )
        {
            Configuration = configuration;
            _env = env;
        }

        public IServiceProvider ConfigureServices( IServiceCollection services )
        {
            AddServices( services );

            return services.BuildServiceProvider();
        }

        public virtual void Configure( IApplicationBuilder app )
        {
            if ( IsDeveloperEnvironment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpGlobalExceptionHandler()
                .UseMvcWithDefaultRoute();
        }

        public virtual void AddServices( IServiceCollection services )
        {
            ConfigureDatabase( services );

            services
                .AddBaseServices( Configuration )
                .AddApplication()
                .AddVersioning( 1, 0 )
                .AddDefaultMvc( "Api" )
                .AddJsonOptions(
                    options =>
                    {
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        options.SerializerSettings.Converters.Add( new StringEnumConverter() );
                    } );
        }

        public virtual void ConfigureDatabase( IServiceCollection services )
        {
            services.AddDatabase<ProjectContext>( Configuration.GetConnectionString( "ProjectConnection" ) );
        }

        private bool IsDeveloperEnvironment()
        {
            string[] developerEnvironments = {"aktuganovdenis"};

            return developerEnvironments.Any( _env.IsEnvironment );
        }
    }
}
