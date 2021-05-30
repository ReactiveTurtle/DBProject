using Domain.Shared;
using Toolkit.Domain.Abstractions;

namespace Domain.InvoiceModel
{
    public class SignerPreset : Entity, IAggregateRoot
    {
        public Signer Signer { get; private set; }
        
        public SignerPreset(Signer signer)
        {
            Update(signer);
        }
        
        // Workaround for EF
        protected SignerPreset()
        {
        }

        public void Update(Signer signer)
        {
            Signer = signer;
        }
    }
}