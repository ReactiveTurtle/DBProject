using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class ProductInInvoice : Entity
    {
        public int ProductId { get; private set; }
        
        public int InvoiceId { get; private set; }
        
        public ProductInInvoice(int productId, int invoiceId)
        {
            ProductId = productId;
            InvoiceId = invoiceId;
        }
        
        // Workaround for EF
        protected ProductInInvoice()
        {
        }
    }
}