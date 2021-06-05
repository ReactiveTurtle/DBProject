using Toolkit.Search;

namespace Api.MessageContracts.Shared
{
    public static class BaseSearchPatternMapper
    {
        public static BaseSearchPattern Map( this BaseSearchPatternDto searchPatternDto )
        {
            return new( searchPatternDto.PageNumber, searchPatternDto.OnPageCount )
            {
                SearchString = searchPatternDto.SearchString
            };
        }
    }
}
