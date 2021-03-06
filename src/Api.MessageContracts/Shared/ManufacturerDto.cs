using System.Runtime.Serialization;

namespace Api.MessageContracts.Shared
{
    [DataContract]
    public class ManufacturerDto
    {
        [DataMember(Name = "name")] public string Name { get; set; }
        [DataMember(Name = "address")] public string Address { get; set; }
        [DataMember(Name = "phoneNumber")] public string PhoneNumber { get; set; }
        [DataMember(Name = "email")] public string Email { get; set; }
        [DataMember(Name = "managerFullname")] public string ManagerFullname { get; set; }
    }
}