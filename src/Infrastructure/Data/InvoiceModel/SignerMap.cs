using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel
{
    public class SignerMap : IEntityTypeConfiguration<Signer>
    {
        public void Configure(EntityTypeBuilder<Signer> builder)
        {
            builder.HasKey( x => x.Id );
            builder.Property( x => x.Id )
                .ForSqlServerUseSequenceHiLo( HiLoSequence.DBSequenceHiLoForSigner );
            
            builder.Property( x => x.Fullname )
                .IsRequired();
            
            builder.Property( x => x.Position )
                .IsRequired();
            
            builder.Property( x => x.Address )
                .IsRequired();
            
            builder.Property( x => x.PhoneNumber )
                .IsRequired();
            
            builder.HasMany<Invoice>()
                .WithOne( x => x.Signer )
                .OnDelete( DeleteBehavior.Cascade );
        }
    }
}