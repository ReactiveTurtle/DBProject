import {CurrencyType} from './currency-type.enum';

export interface IProduct {
    readonly name: string;
    readonly price: number;
    readonly currencyType: CurrencyType;
    readonly manufactureDateTime: Date;
    readonly expirationDateTime: Date;
}
