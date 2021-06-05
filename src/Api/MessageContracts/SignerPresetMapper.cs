using Api.MessageContracts.Shared;
using Domain.InvoiceModel;

namespace Api.MessageContracts
{
    public static class SignerPresetMapper
    {
        public static SignerPresetDto Map(this SignerPreset signerPreset)
        {
            return new()
            {
                Id = signerPreset.Id,
                Signer = signerPreset.Signer.Map()
            };
        }
    }
}