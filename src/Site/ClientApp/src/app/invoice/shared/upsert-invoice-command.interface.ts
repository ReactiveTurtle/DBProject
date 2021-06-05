import {IProductPreset} from '../../product/shared/product-preset.interface';

export interface IUpsertInvoiceCommand {
    readonly name: string;
    readonly preparationDate: Date;
    readonly signerPresetId: number;
    readonly productPresets: IProductPreset[];
}
