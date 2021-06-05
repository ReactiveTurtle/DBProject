using System.Runtime.Serialization;
using Api.MessageContracts.Shared;

namespace Api.MessageContracts
{
    [DataContract]
    public class SignerPresetDto
    {
        [DataMember(Name = "id")] public int Id { get; set; }

        [DataMember(Name = "signer")] public SignerDto Signer { get; set; }
    }
}