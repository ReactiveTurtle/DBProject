using System.Runtime.Serialization;

namespace Api.MessageContracts.Shared
{
    [DataContract]
    public class SignerDto
    {
        [DataMember(Name = "fullname")] public string Fullname { get; set; }

        [DataMember(Name = "position")] public string Position { get; set; }

        [DataMember(Name = "address")] public string Address { get; set; }

        [DataMember(Name = "phoneNumber")] public string PhoneNumber { get; set; }
    }
}