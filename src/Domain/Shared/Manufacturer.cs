using System.Collections.Generic;
using Toolkit.Domain.Abstractions;

namespace Domain.Shared
{
    public class Manufacturer : ValueObject<Manufacturer>
    {
        public string Name { get; private set; }

        public string Address { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string ManagerFullname { get; private set; }

        public Manufacturer(
            string name,
            string address,
            string phoneNumber,
            string email, 
            string managerFullname)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            ManagerFullname = managerFullname;
        }
        
        // Workaround for EF
        protected Manufacturer()
        {
        }

        public override Manufacturer Copy()
        {
            return new Manufacturer(
                Name,
                Address,
                PhoneNumber,
                Email,
                ManagerFullname);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return PhoneNumber;
            yield return Email;
            yield return ManagerFullname;
        }
    }
}