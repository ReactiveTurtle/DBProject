using System;
using System.Collections.Generic;
using Domain.Shared;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public partial class Invoice : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public DateTime PreparationDate { get; private set; }

        public Signer Signer { get; private set; }

        public virtual IReadOnlyList<Product> Products => _products;

        private readonly List<Product> _products = new List<Product>();

        // Workaround for EF
        protected Invoice()
        {
        }

        public void AddProducts(Product product, params Product[] products)
        {
            _products.Add(product);
            _products.AddRange(products);
        }
    }
}