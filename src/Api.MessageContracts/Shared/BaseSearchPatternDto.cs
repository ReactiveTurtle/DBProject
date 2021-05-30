using System.Runtime.Serialization;

namespace Api.MessageContracts.Shared
{
    [DataContract]
    public class BaseSearchPatternDto
    {
        [DataMember( Name = "pageNumber" )]
        public int PageNumber { get; set; }

        [DataMember( Name = "onPageCount" )]
        public int OnPageCount { get; set; }

        [DataMember( Name = "searchString" )]
        public string SearchString { get; set; }
    }
}
