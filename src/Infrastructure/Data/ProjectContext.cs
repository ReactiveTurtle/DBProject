using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.InvoiceModel;
using Infrastructure.Data.InvoiceModel.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Toolkit.Clock;
using Toolkit.Domain.Abstractions;

namespace Infrastructure.Data
{
    public class ProjectContext : DbContext, IUnitOfWork
    {
        private readonly IClock _clock;

        public ProjectContext(
            DbContextOptions<ProjectContext> options,
            IClock clock ) : base( options )
        {
            _clock = clock;
        }

        private ProjectContext( DbContextOptions<ProjectContext> options ) : base( options )
        {
        }
        
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<SignerPreset> Signer { get; set; }
        public DbSet<ProductPreset> Product { get; set; }
        public DbSet<ManufacturerPreset> Manufacturer { get; set; }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );
            
            builder.HasSequence<int>( HiLoSequence.DBSequenceHiLoForInvoice )
                .StartsAt( 1 ).IncrementsBy( 1 );
            builder.HasSequence<int>( HiLoSequence.DBSequenceHiLoForSigner )
                .StartsAt( 1 ).IncrementsBy( 1 );
            builder.HasSequence<int>( HiLoSequence.DBSequenceHiLoForProduct )
                .StartsAt( 1 ).IncrementsBy( 1 );
            builder.HasSequence<int>( HiLoSequence.DBSequenceHiLoForManufacturer )
                .StartsAt( 1 ).IncrementsBy( 1 );

            builder.ApplyConfiguration( new InvoiceMap() );
            builder.ApplyConfiguration( new SignerPresetMap() );
            builder.ApplyConfiguration( new ProductPresetMap() );
            builder.ApplyConfiguration( new ManufacturerPresetMap() );

            foreach ( var property in builder.Model.GetEntityTypes().SelectMany( t => t.GetProperties() ) )
            {
                if ( property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?) )
                {
                    property.Relational().ColumnType = "decimal(19, 4)";
                }
                else if ( property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?) )
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => DateTime.SpecifyKind( v, DateTimeKind.Utc ) ) );

                    if ( property.ValueGenerated != ValueGenerated.Never )
                    {
                        property.SetValueGeneratorFactory( ( _, __ ) => new DateTimeNowGenerator( _clock ) );
                    }
                }
            }
        }

        public async Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default )
        {
            await SaveChangesAsync( cancellationToken );

            return true;
        }
    }
}
