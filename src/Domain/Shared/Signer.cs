using System.Collections.Generic;
using Toolkit.Domain.Abstractions;

namespace Domain.Shared
{
    public class Signer : ValueObject<Signer>
    {
        public string Fullname { get; private set; }
        
        public string Position { get; private set; }
        
        public string Address { get; private set; }
        
        public string PhoneNumber { get; private set; }
        
        public Signer(
            string fullname, 
            string position,
            string address,
            string phoneNumber)
        {
            Fullname = fullname;
            Position = position;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        
        // Workaround for EF
        protected Signer()
        {
        }
        
        public override Signer Copy()
        {
            return new Signer(
                Fullname,
                Position,
                Address,
                PhoneNumber);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Fullname;
            yield return Position;
            yield return Address;
            yield return PhoneNumber;
        }
    }
}