import {ISigner} from './signer.interface';

export interface ISignerPreset {
    readonly id: number;
    readonly signer: ISigner;
}
