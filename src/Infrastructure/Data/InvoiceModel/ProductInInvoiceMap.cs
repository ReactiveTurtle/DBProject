using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.InvoiceModel
{
    public class ProductInInvoiceMap : IEntityTypeConfiguration<ProductInInvoice>
    {
        public void Configure(EntityTypeBuilder<ProductInInvoice> builder)
        {
            builder.Property(x => x.InvoiceId)
                .IsRequired();
            
            builder.Property(x => x.ProductId)
                .IsRequired();
            
            builder.Property(x => x.Count)
                .IsRequired();

            builder.HasOne<Invoice>()
                .WithMany(x => x.Products)
                .OnDelete( DeleteBehavior.Cascade )
                .HasForeignKey(x => x.InvoiceId)
                .HasForeignKey(x => x.ProductId);
        }
    }
}