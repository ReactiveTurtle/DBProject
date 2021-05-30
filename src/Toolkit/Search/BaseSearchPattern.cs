using System;

namespace Toolkit.Search
{
    public class BaseSearchPattern
    {
        public BaseSearchPattern( int pageNumber = 1, int onPageCount = 25 )
        {
            if ( pageNumber < 1 )
            {
                throw new InvalidOperationException( $"Incorrect page number: {pageNumber}" );
            }

            if ( onPageCount < 1 )
            {
                throw new InvalidOperationException( $"Incorrect on page count: {onPageCount}" );
            }

            PageNumber = pageNumber;
            OnPageCount = onPageCount;
        }

        public int PageNumber { get; set; }

        public int OnPageCount { get; set; }

        public string SearchString { get; set; }

        public int Skip()
        {
            return ( PageNumber - 1 ) * OnPageCount;
        }

        public int Take()
        {
            return OnPageCount;
        }
    }
}
