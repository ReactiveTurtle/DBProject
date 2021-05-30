using System.Diagnostics.Contracts;
using System.Linq;
using Domain.InvoiceModel;
using Toolkit.Search;

namespace Api.MessageContracts.Shared
{
    public static class SearchResultMapper
    {
        public static SearchResultDto<ManufacturerPresetDto> Map( this SearchResult<ManufacturerPreset> searchResult )
        {
            return new SearchResultDto<ManufacturerPresetDto>
            {
                FilteredCount = searchResult.FilteredCount,
                Items = searchResult.Items.Select( x => x.Map() ),
                TotalCount = searchResult.TotalCount
            };
        }
    }
}
