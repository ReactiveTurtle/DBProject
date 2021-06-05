using System;
using System.Runtime.Serialization;
using Api.MessageContracts.Shared;

namespace Api.MessageContracts
{
    [DataContract]
    public class UpsertProductDto
    {
        [DataMember(Name = "manufacturerId")] public int ManufacturerId { get; set; }
        
        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "price")] public decimal Price { get; set; }

        [DataMember(Name = "currencyType")] public CurrencyType CurrencyType { get; set; }

        [DataMember(Name = "manufactureDateTime")]
        public DateTimeOffset ManufactureDateTime { get; set; }

        [DataMember(Name = "expirationDateTime")]
        public DateTimeOffset ExpirationDateTime { get; set; }
    }
}