using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel.EntityConfigurations
{
    public class ProductInInvoiceMap : IEntityTypeConfiguration<ProductInInvoice>
    {
        public void Configure(EntityTypeBuilder<ProductInInvoice> builder)
        {
            builder.Property(x => x.InvoiceId)
                .IsRequired();
            
            builder.Property(x => x.ProductId)
                .IsRequired();
            
            builder.HasOne<Invoice>()
                .WithMany()
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}