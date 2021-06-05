using System;

namespace Toolkit.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfArgumentNull( this object obj, string argumentName )
        {
            if ( obj == null )
            {
                throw new ArgumentNullException( argumentName );
            }
        }
    }
}
