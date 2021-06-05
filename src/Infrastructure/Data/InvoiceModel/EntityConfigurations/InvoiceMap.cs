using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ForSqlServerUseSequenceHiLo(HiLoSequence.DBSequenceHiLoForInvoice);

            builder.Property(x => x.Name)
                .HasMaxLength(Invoice.NameMaxLength)
                .IsRequired();

            builder.Property(x => x.SignerId)
                .IsRequired();

            builder.Property(x => x.PreparationDate)
                .IsRequired();

            builder.Metadata
                .FindNavigation(nameof(Invoice.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}