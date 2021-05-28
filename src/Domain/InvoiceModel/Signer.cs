using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class Signer : Entity
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
    }
}