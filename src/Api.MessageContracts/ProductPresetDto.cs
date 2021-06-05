using System.Runtime.Serialization;
using Api.MessageContracts.Shared;

namespace Api.MessageContracts
{
    [DataContract]
    public class ProductPresetDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }

        [DataMember(Name = "manufacturerPreset")] public ManufacturerPresetDto ManufacturerPreset { get; set; }

        [DataMember(Name = "product")] public ProductDto Product { get; set; }
    }
}