using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class SignerMap : IEntityTypeConfiguration<SignerPreset>
    {
        public void Configure(EntityTypeBuilder<SignerPreset> builder)
        {
            builder.HasKey( x => x.Id );
            builder.Property( x => x.Id )
                .ForSqlServerUseSequenceHiLo( HiLoSequence.DBSequenceHiLoForSigner );

            builder.OwnsOne(value => value.Signer,
                signerBuilder =>
                {
                    signerBuilder.Property( x => x.Fullname )
                        .IsRequired();
            
                    signerBuilder.Property( x => x.Position )
                        .IsRequired();
            
                    signerBuilder.Property( x => x.Address )
                        .IsRequired();
            
                    signerBuilder.Property( x => x.PhoneNumber )
                        .IsRequired();
                });
        }
    }
}