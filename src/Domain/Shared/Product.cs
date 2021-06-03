using System;
using System.Collections.Generic;
using Domain.InvoiceModel;
using Toolkit.Domain.Abstractions;

namespace Domain.Shared
{
    public class Product : ValueObject<Product>
    {
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
            string name,
            decimal price,
            CurrencyType currencyType,
            DateTime manufactureDateTime,
            DateTime expirationDateTime)
        {
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

        public override Product Copy()
        {
            return new Product(
                Name,
                Price,
                CurrencyType,
                ManufactureDateTime,
                ExpirationDateTime);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Price;
            yield return CurrencyType;
            yield return ManufactureDateTime;
            yield return ExpirationDateTime;
        }
    }
}