using Domain.Shared;

namespace Api.MessageContracts.Shared
{
    public static class ProductMapper
    {
        public static ProductDto Map(this Product product)
        {
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                CurrencyType = product.CurrencyType.Map(),
                ManufactureDateTime = product.ManufactureDateTime,
                ExpirationDateTime = product.ExpirationDateTime
            };
        }
    }
}