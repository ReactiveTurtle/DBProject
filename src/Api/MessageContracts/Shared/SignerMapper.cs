using Domain.Shared;

namespace Api.MessageContracts.Shared
{
    public static class SignerMapper
    {
        public static SignerDto Map(this Signer signer)
        {
            return new()
            {
                Fullname = signer.Fullname,
                Position = signer.Position,
                Address = signer.Address,
                PhoneNumber = signer.PhoneNumber
            };
        }
    }
}