import {Pipe, PipeTransform} from '@angular/core';
import {BaseNamePipe} from 'src/app/shared/base-name';
import {CurrencyType} from './currency-type.enum';

@Pipe({
    name: 'currencyType'
})
export class CurrencyTypePipe extends BaseNamePipe<CurrencyType> implements PipeTransform {
    constructor() {
        super([
            [CurrencyType.Ruble, '₽'],
            [CurrencyType.Dollar, '$']
        ]);
    }
}
