using System;
using Domain.InvoiceModel;
using Infrastructure.Data.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISignerRepository, SignerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

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
