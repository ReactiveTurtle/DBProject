using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel
{
    public class ManufacturerMap : IEntityTypeConfiguration<ManufacturerPreset>
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
        }
    }
}