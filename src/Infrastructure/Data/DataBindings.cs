using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            return services;
        }

        public static IServiceCollection AddDatabase<T>( this IServiceCollection services, string connectionString )
            where T : DbContext
        {
            return services.AddDbContext<T>( c =>
            {
                try
                {
                    c.UseSqlServer( connectionString );
                }
                catch ( Exception )
                {
                    //var message = ex.Message;
                }
            } );
        }
    }
}
