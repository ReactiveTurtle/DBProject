using System.Collections.Generic;
using System.Threading.Tasks;
using Toolkit.Domain.Abstractions;
using Toolkit.Exceptions;

namespace Toolkit.Extensions
{
    public static class ExceptionExtensions
    {
        public static T ThrowIfEntityNotFound<T>( this T entity, int entityId ) where T : IEntity
        {
            if ( EqualityComparer<T>.Default.Equals( entity, default ) )
            {
                throw new EntityNotFoundException( typeof(T), entityId );
            }

            return entity;
        }

        public static async Task<T> ThrowIfEntityNotFound<T>( this Task<T> task, int entityId ) where T : IEntity
        {
            return ( await task ).ThrowIfEntityNotFound( entityId );
        }
    }
}
