using Domain.InvoiceModel;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Infrastructure.Data.InvoiceModel
{
    public class ProductMap : IEntityTypeConfiguration<ProductPreset>
    {
        public void Configure(EntityTypeBuilder<ProductPreset> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForProduct);

            builder.OwnsOne(value => value.Product,
                (productBuilder) =>
                {
                    productBuilder.Property("Manufacturer")
                        .HasConversion(new ValueConverter<Manufacturer, string>(
                            value => JsonConvert.SerializeObject(value),
                            value => JsonConvert.DeserializeObject<Manufacturer>(value)))
                        .IsRequired();

                    productBuilder.Property(value => value.Name)
                        .IsRequired();

                    productBuilder.Property(value => value.Price)
                        .IsRequired();

                    productBuilder.Property(value => value.CurrencyType)
                        .IsRequired();

                    productBuilder.Property(value => value.ManufactureDateTime)
                        .IsRequired();

                    productBuilder.Property(value => value.ExpirationDateTime)
                        .IsRequired();
                });
        }
    }
}