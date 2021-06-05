import {ISignerPreset} from '../../signer/shared/signer-preset.interface';
import {IProductPreset} from '../../product/shared/product-preset.interface';

export interface IInvoice {
    readonly id: number;
    readonly name: string;
    readonly preparationDate: Date;
    readonly signerPreset: ISignerPreset;
    readonly productPresets: IProductPreset[];
}
