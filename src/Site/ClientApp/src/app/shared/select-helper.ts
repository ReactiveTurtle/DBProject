import {SelectOption} from './select-option.model';

export abstract class SelectHelper {
    public static enumToSelectOptions(enumObject, pipe): Array<SelectOption> {
        return Object.keys(enumObject)
            .map(value => new SelectOption(value, pipe.transform(value)));
    }
}
