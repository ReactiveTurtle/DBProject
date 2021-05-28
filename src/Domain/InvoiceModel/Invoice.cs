using System;
using System.Collections.Generic;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public partial class Invoice : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public DateTime PreparationDate { get; private set; }

        public Signer Signer { get; private set; }

        public virtual IReadOnlyList<ProductInInvoice> Products => _products;

        private readonly List<ProductInInvoice> _products = new List<ProductInInvoice>();

        // Workaround for EF
        protected Invoice()
        {
        }

        public void AddProduct(int productId, int count)
        {
            _products.Add(new ProductInInvoice(Id, productId, count));
        }
    }
}