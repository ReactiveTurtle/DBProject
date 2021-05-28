using System;

namespace Toolkit.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException( Type type, int entityId ) :
            base( $"Entity {type.Name} with ID='{entityId}' not found" )
        {
        }
    }
}
