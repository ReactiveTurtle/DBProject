using System.Collections.Generic;
using System.Linq;
using Api.MessageContracts.Shared;
using Domain.InvoiceModel;
using Toolkit.Extensions;

namespace Api.MessageContracts
{
    public static class ProductPresetMapper
    {
        public static ProductPresetDto Map(
            this ProductPreset productPreset,
            ManufacturerPreset manufacturerPreset)
        {
            return new()
            {
                Id = productPreset.Id,
                ManufacturerPreset = manufacturerPreset.Map(),
                Product = productPreset.Product.Map()
            };
        }
        
        public static IReadOnlyList<ProductPresetDto> Map(
            this IEnumerable<ProductPreset> productPresets,
            IReadOnlyDictionary<int, ManufacturerPreset> manufacturerPresets)
        {
            return productPresets.Select(x =>
            {
                manufacturerPresets.TryGetValue(x.ManufacturerId, out var manufacturerPreset);
                manufacturerPreset.ThrowIfArgumentNull(nameof(manufacturerPreset));
                return x.Map(manufacturerPreset);
            }).ToList().AsReadOnly();
        }
    }
}