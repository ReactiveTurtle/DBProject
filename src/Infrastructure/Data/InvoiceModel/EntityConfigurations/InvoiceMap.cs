using Domain.InvoiceModel;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForInvoice);
            
            builder.Property( x => x.Name )
                .HasMaxLength( Invoice.NameMaxLength )
                .IsRequired();
            
            builder.Property( x => x.PreparationDate )
                .IsRequired();
            
            builder.Property("Signer")
                .HasConversion(new ValueConverter<Signer, string>(
                    value => JsonConvert.SerializeObject(value),
                    value => JsonConvert.DeserializeObject<Signer>(value)))
                .IsRequired();

            builder.Metadata
                .FindNavigation(nameof(Invoice.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}