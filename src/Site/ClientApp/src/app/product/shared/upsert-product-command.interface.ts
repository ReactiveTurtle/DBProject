import {CurrencyType} from "./currency-type.enum";

export interface IUpsertProductCommand {
    readonly manufacturerId: number;
    readonly name: string;
    readonly price: number;
    readonly currencyType: CurrencyType;
    readonly manufactureDateTime: Date;
    readonly expirationDateTime: Date;
}