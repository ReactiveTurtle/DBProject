using System.Runtime.Serialization;

namespace Infrastructure.Web
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember( Name = "title" )]
        public string Title { get; set; }

        [DataMember( Name = "details" )]
        public string Details { get; set; }

        public ErrorResponse( string title = null, string details = null )
        {
            Title = title;
            Details = details;
        }
    }
}
