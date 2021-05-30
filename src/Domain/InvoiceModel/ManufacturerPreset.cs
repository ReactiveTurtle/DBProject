using Domain.Shared;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class ManufacturerPreset : Entity, IAggregateRoot
    {
        public Manufacturer Manufacturer { get; private set; }

        public ManufacturerPreset(Manufacturer manufacturer)
        {
            Update(manufacturer);
        }
        
        // Workaround for EF
        protected ManufacturerPreset()
        {
        }

        public void Update(Manufacturer manufacturer)
        {
            Manufacturer = manufacturer;
        }
    }
}