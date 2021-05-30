using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Toolkit.Clock;

namespace Infrastructure.Migrations
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        private readonly IClock _clock;

        public DesignTimeRepositoryContextFactory( IClock clock )
        {
            _clock = clock;
        }

        public DesignTimeRepositoryContextFactory()
        {
        }

        public ProjectContext CreateDbContext( string[] args )
        {
            IConfiguration config = MigrationExtension.GetConfig();
            string connectionString = config.GetConnectionString( "ProjectConnection" );

            var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            optionsBuilder.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly( "Infrastructure.Migrations" ) );

            return new ProjectContext( optionsBuilder.Options, _clock );
        }
    }
}
