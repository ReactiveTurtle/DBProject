using Domain.Shared;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    /// <summary>
    /// Товар
    /// </summary>
    public class ProductPreset : Entity, IAggregateRoot
    {
        /// <summary>
        /// Данные о производителе товара
        /// </summary>
        public int ManufacturerId { get; private set; }
        
        public Product Product { get; private set; }

        public ProductPreset(int manufacturerId, Product product)
        {
            Update(manufacturerId, product);
        }

        // Workaround for EF
        protected ProductPreset()
        {
        }
        
        public void Update(int manufacturerId, Product product)
        {
            ManufacturerId = manufacturerId;
            Product = product;
        }
    }
}