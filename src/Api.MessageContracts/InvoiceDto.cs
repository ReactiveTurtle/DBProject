using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Api.MessageContracts.Shared;

namespace Api.MessageContracts
{
    [DataContract]
    public class InvoiceDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }

        [DataMember(Name = "name")] public string Name { get; set; }

        [DataMember(Name = "preparationDate")] public DateTimeOffset PreparationDate { get; set; }

        [DataMember(Name = "signerPreset")] public SignerPresetDto SignerPreset { get; set; }

        [DataMember(Name = "productPresets")] public IReadOnlyList<ProductPresetDto> ProductPresets { get; set; }
    }
}