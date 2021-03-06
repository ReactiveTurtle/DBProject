using Domain.InvoiceModel;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class SignerPresetMap : IEntityTypeConfiguration<SignerPreset>
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
            
            builder.HasMany<Invoice>()
                .WithOne()
                .HasForeignKey(x => x.SignerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}