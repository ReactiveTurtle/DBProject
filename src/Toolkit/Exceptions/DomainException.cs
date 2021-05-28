using System;

namespace Toolkit.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException( string message ) : base( message )
        {
        }
    }
}
