using System.Collections.Generic;
using System.Linq;
using Domain.InvoiceModel;
using Toolkit.Extensions;
using Toolkit.Search;

namespace Api.MessageContracts.Shared
{
    public static class SearchResultMapper
    {
        public static SearchResultDto<ManufacturerPresetDto> Map(this SearchResult<ManufacturerPreset> searchResult)
        {
            return new()
            {
                FilteredCount = searchResult.FilteredCount,
                Items = searchResult.Items.Select(x => x.Map()),
                TotalCount = searchResult.TotalCount
            };
        }

        public static SearchResultDto<ProductPresetDto> Map(
            this SearchResult<ProductPreset> searchResult,
            IReadOnlyDictionary<int, ManufacturerPreset> manufacturerPresets)
        {
            return new()
            {
                FilteredCount = searchResult.FilteredCount,
                Items = searchResult.Items.Map(manufacturerPresets),
                TotalCount = searchResult.TotalCount
            };
        }

        public static SearchResultDto<SignerPresetDto> Map(this SearchResult<SignerPreset> searchResult)
        {
            return new()
            {
                FilteredCount = searchResult.FilteredCount,
                Items = searchResult.Items.Select(x => x.Map()),
                TotalCount = searchResult.TotalCount
            };
        }
        
        public static SearchResultDto<InvoiceDto> Map(
            this SearchResult<Invoice> searchResult, 
            IReadOnlyDictionary<int, ProductPresetDto> productPresets, 
            IReadOnlyDictionary<int, SignerPreset> signerPresets)
        {
            return new()
            {
                FilteredCount = searchResult.FilteredCount,
                Items = searchResult.Items.Select(x =>
                {
                    signerPresets.TryGetValue(x.SignerId, out var signerPreset);
                    return x.Map(productPresets, signerPreset);
                }),
                TotalCount = searchResult.TotalCount
            };
        }
    }
}