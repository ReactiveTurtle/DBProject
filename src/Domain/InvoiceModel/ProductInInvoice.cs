using System.Collections.Generic;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class ProductInInvoice : ValueObject<ProductInInvoice>
    {
        /// <summary>
        /// Id накладной, в которую записан товар
        /// </summary>
        public int InvoiceId { get; private set; }
        
        /// <summary>
        /// Id товара
        /// </summary>
        public int ProductId { get; private set; }

        /// <summary>
        /// Количество товаров этого вида в накладной
        /// </summary>
        public int Count { get; private set; }
        
        public ProductInInvoice(
            int invoiceId, 
            int productId,
            int count)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            UpdateCount(count);
        }
        
        // Workaround for EF
        protected ProductInInvoice()
        {
        }

        public void UpdateCount(int count)
        {
            Count = count;
        }

        public override ProductInInvoice Copy()
        {
            return new ProductInInvoice(InvoiceId, ProductId, Count);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return InvoiceId;
            yield return ProductId;
            yield return Count;
        }
    }
}