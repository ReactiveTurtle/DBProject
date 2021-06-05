using System;
using Domain.Shared;

namespace Api.MessageContracts.Shared
{
    public static class CurrencyTypeMapper
    {
        public static CurrencyType Map(this Domain.InvoiceModel.CurrencyType currencyType)
        {
            return currencyType switch
            {
                Domain.InvoiceModel.CurrencyType.Ruble => CurrencyType.Ruble,
                Domain.InvoiceModel.CurrencyType.Dollar => CurrencyType.Dollar,
                _ => throw new ArgumentOutOfRangeException(nameof(currencyType))
            };
        }

        public static Domain.InvoiceModel.CurrencyType Map(this CurrencyType currencyType)
        {
            return currencyType switch
            {
                CurrencyType.Ruble => Domain.InvoiceModel.CurrencyType.Ruble,
                CurrencyType.Dollar => Domain.InvoiceModel.CurrencyType.Dollar,
                _ => throw new ArgumentOutOfRangeException(nameof(currencyType))
            };
        }
    }
}