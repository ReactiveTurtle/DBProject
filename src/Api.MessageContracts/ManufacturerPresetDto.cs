using System.Runtime.Serialization;
using Api.MessageContracts.Shared;

namespace Api.MessageContracts
{
    [DataContract]
    public class ManufacturerPresetDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }
        [DataMember(Name = "manufacturer")] public ManufacturerDto Manufacturer { get; set; }
    }
}