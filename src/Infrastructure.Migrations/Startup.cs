using System;
using System.Linq;
using Infrastructure.Clock;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Toolkit.Clock;

namespace Infrastructure.Migrations
{
    public class Startup : IStartup
    {
        private readonly IConfiguration _configuration;

        public Startup( IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public IServiceProvider ConfigureServices( IServiceCollection services )
        {
            Console.WriteLine(
                $"Migration run as user: \"{System.Security.Principal.WindowsIdentity.GetCurrent().Name}\"");

            Console.WriteLine(
                $"Migration connection string: \"{_configuration.GetConnectionString("ProjectConnection")}\"");

            services.AddDbContext<ProjectContext>( x =>
                    x.UseSqlServer( _configuration.GetConnectionString( "ProjectConnection" ) ) )
                .AddClock();

            return services.BuildServiceProvider();
        }

        public virtual void Configure( IApplicationBuilder app )
        {
            InitializeDatabase( app );
        }

        private void InitializeDatabase( IApplicationBuilder app )
        {
            using ( var scope = app.ApplicationServices.CreateScope() )
            {
                IClock clock = scope.ServiceProvider.GetService<IClock>();
                var contextFactory = new DesignTimeRepositoryContextFactory( clock );
                ProjectContext context = contextFactory.CreateDbContext( new string[] { } );
                context.Database.Migrate();

                string[] appliedMigrations = context.Database.GetAppliedMigrations().ToArray();
                Console.WriteLine( String.Join( "\n", appliedMigrations ) );
            }
        }
    }
}
