using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForProductPreset);

            builder.Property(value => value.Manufacturer)
                .IsRequired();
            
            builder.Property(value => value.Name)
                .IsRequired();

            builder.Property(value => value.Price)
                .IsRequired();

            builder.Property(value => value.CurrencyType)
                .IsRequired();

            builder.Property(value => value.ManufactureDateTime)
                .IsRequired();

            builder.Property(value => value.ExpirationDateTime)
                .IsRequired();
            
            builder.Metadata
                .FindNavigation( nameof( Product.Manufacturer ) )
                .SetPropertyAccessMode( PropertyAccessMode.Field );
        }
    }
}