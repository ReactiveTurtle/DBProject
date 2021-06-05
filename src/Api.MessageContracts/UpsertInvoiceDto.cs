using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.MessageContracts
{
    [DataContract]
    public class UpsertInvoiceDto
    {
        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "preparationDate")] public DateTimeOffset PreparationDate { get; set; }

        [DataMember(Name = "signerPresetId")] public int SignerPresetId { get; set; }

        [DataMember(Name = "productPresets")] public IReadOnlyList<ProductPresetDto> ProductPresets { get; set; }
    }
}