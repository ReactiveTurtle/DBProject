using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.MessageContracts.Shared
{
    [DataContract]
    public class SearchResultDto<T>
    {
        [DataMember( Name = "items" )]
        public IEnumerable<T> Items { get; set; }

        [DataMember( Name = "totalCount" )]
        public int TotalCount { get; set; }

        [DataMember( Name = "filteredCount" )]
        public int FilteredCount { get; set; }
    }
}
