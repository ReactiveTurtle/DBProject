using System.Collections.Generic;

namespace Toolkit.Search
{
    public class SearchResult<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }
    }
}
