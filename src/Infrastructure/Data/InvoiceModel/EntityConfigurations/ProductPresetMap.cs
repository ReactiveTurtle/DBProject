using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class ProductPresetMap : IEntityTypeConfiguration<ProductPreset>
    {
        public void Configure(EntityTypeBuilder<ProductPreset> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForProduct);

            builder.Property(value => value.ManufacturerId)
                .IsRequired();
            
            builder.OwnsOne(value => value.Product,
                (productBuilder) =>
                {
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

            builder.HasMany<ProductInInvoice>()
                .WithOne()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}