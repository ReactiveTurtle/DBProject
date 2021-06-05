using System.Collections.Generic;
using System.Linq;
using Domain.InvoiceModel;
using Toolkit.Extensions;

namespace Api.MessageContracts
{
    public static class InvoiceMapper
    {
        public static InvoiceDto Map(
            this Invoice invoice,
            IReadOnlyDictionary<int, ProductPresetDto> products,
            SignerPreset signerPreset)
        {
            return new()
            {
                Id = invoice.Id,
                Name = invoice.Name,
                PreparationDate = invoice.PreparationDate,
                SignerPreset = signerPreset.Map(),
                ProductPresets = invoice.Products.Select(x =>
                {
                    products.TryGetValue(x.ProductId, out var productPresetDto);
                    productPresetDto.ThrowIfArgumentNull(nameof(productPresetDto));
                    return productPresetDto;
                }).ToList().AsReadOnly()
            };
        }
    }
}