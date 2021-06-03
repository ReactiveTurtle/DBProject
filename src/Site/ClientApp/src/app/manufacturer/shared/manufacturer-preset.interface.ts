import {IManufacturer} from './manufacturer.interface';

export interface IManufacturerPreset {
  readonly id: number;
  readonly manufacturer: IManufacturer;
}
