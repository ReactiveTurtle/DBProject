using System;
using Domain.Shared;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    /// <summary>
    /// Товар
    /// </summary>
    public class ProductPreset : Entity, IAggregateRoot
    {
        public Product Product { get; private set; }

        public ProductPreset(Product product)
        {
            Update(product);
        }

        // Workaround for EF
        protected ProductPreset()
        {
        }
        
        public void Update(Product product)
        {
            Product = product;
        }
    }
}