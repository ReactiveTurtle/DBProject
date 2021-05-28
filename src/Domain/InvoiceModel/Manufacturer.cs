using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class Manufacturer : Entity
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
            Update(name, address, phoneNumber, email, managerFullname);
        }
        
        // Workaround for EF
        protected Manufacturer()
        {
        }

        public void Update(
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
    }
}