using Domain.InvoiceModel;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class ManufacturerPresetMap : IEntityTypeConfiguration<ManufacturerPreset>
    {
        public void Configure(EntityTypeBuilder<ManufacturerPreset> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForManufacturer);

            builder.OwnsOne(value => value.Manufacturer,
                manufacturerBuilder =>
                {
                    manufacturerBuilder.Property(x => x.Name)
                        .IsRequired();

                    manufacturerBuilder.Property(x => x.Address)
                        .IsRequired();

                    manufacturerBuilder.Property(x => x.PhoneNumber)
                        .IsRequired();

                    manufacturerBuilder.Property(x => x.ManagerFullname)
                        .IsRequired();
                });
            
            builder.HasMany<ProductPreset>()
                .WithOne()
                .HasForeignKey(x => x.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}