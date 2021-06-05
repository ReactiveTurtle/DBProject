using Domain.Shared;

namespace Api.MessageContracts.Shared
{
    public static class ManufacturerMapper
    {
        public static ManufacturerDto Map(this Manufacturer manufacturer)
        {
            return new()
            {
                Name = manufacturer.Name,
                Address = manufacturer.Address,
                PhoneNumber = manufacturer.PhoneNumber,
                Email = manufacturer.Email,
                ManagerFullname = manufacturer.ManagerFullname
            };
        }
    }
}