using System;
using System.Runtime.Serialization;

namespace Api.MessageContracts.Shared
{
    [DataContract]
    public class ProductDto
    {
        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "price")] public decimal Price { get; set; }

        [DataMember(Name = "currencyType")] public CurrencyType CurrencyType { get; set; }

        [DataMember(Name = "manufactureDateTime")]
        public DateTimeOffset ManufactureDateTime { get; set; }

        [DataMember(Name = "expirationDateTime")]
        public DateTimeOffset ExpirationDateTime { get; set; }
    }
}