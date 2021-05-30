using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Migrations
{
    public static class MigrationExtension
    {
        public static IConfiguration GetConfig()
        {
            string env = Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" );
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{env}.json", true )
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
