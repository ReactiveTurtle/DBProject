using System;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product : Entity
    {
        /// <summary>
        /// Производитель товара
        /// </summary>
        public Manufacturer Manufacturer { get; private set; }
        
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Тип валюты для стоимости товара
        /// </summary>
        public CurrencyType CurrencyType { get; private set; }

        /// <summary>
        /// Дата изготовлеия товара
        /// </summary>
        public DateTime ManufactureDateTime { get; private set; }

        /// <summary>
        /// Дата истечения срока годности
        /// </summary>
        public DateTime ExpirationDateTime { get; private set; }

        public Product(
            Manufacturer manufacturer,
            string name,
            decimal price,
            CurrencyType currencyType,
            DateTime manufactureDateTime,
            DateTime expirationDateTime)
        {
            Manufacturer = manufacturer;
            Name = name;
            Price = price;
            CurrencyType = currencyType;
            ManufactureDateTime = manufactureDateTime;
            ExpirationDateTime = expirationDateTime;
        }

        // Workaround for EF
        protected Product()
        {
        }
    }
}