using Api.MessageContracts.Shared;
using Domain.InvoiceModel;

namespace Api.MessageContracts
{
    public static class ManufacturerPresetMapper
    {
        public static ManufacturerPresetDto Map(this ManufacturerPreset manufacturerPreset)
        {
            return new()
            {
                Id = manufacturerPreset.Id,
                Manufacturer = manufacturerPreset.Manufacturer.Map()
            };
        }
    }
}