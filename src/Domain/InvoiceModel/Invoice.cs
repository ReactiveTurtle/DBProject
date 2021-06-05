using System;
using System.Collections.Generic;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public partial class Invoice : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public DateTime PreparationDate { get; private set; }

        public int SignerId { get; private set; }

        public virtual IReadOnlyList<ProductInInvoice> Products => _products;

        private readonly List<ProductInInvoice> _products = new List<ProductInInvoice>();
        
        public Invoice(string name, DateTime preparationDate, int signerId)
        {
            Name = name;
            PreparationDate = preparationDate;
            SignerId = signerId;
        }
        
        // Workaround for EF
        protected Invoice()
        {
        }

        public void AddProduct(int productId, int invoiceId)
        {
            _products.Add(new ProductInInvoice(productId, invoiceId));
        }
    }
}