import {IProduct} from './product.interface';
import {IManufacturerPreset} from '../../manufacturer/shared/manufacturer-preset.interface';

export interface IProductPreset {
    readonly id: number;
    readonly manufacturerPreset: IManufacturerPreset;
    readonly product: IProduct;
}
