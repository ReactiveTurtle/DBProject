using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel
{
    public class ManufacturerMap : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForManufacturer);

            builder.Property(x => x.Name)
                .IsRequired();
            
            builder.Property(x => x.Address)
                .IsRequired();
            
            builder.Property(x => x.PhoneNumber)
                .IsRequired();
            
            builder.Property(x => x.ManagerFullname)
                .IsRequired();

            builder.HasMany<Product>()
                .WithOne(x => x.Manufacturer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}