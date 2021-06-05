export class BaseNamePipe<T> {
    private _dictionary: Array<[T, string]>;

    constructor(initDictionary: Array<[T, string]>) {
        this._dictionary = initDictionary;
    }

    private findValue(key: T): string | undefined {
        const value: [T, string] | undefined = this._dictionary.find(item => item[0] === key);
        if (value === undefined) {
            return undefined;
        }
        return value[1];
    }

    public transform(value: T): string {
        const v = this.findValue(value);
        if (v === undefined) {
            console.error(`Not found switch case for value '${value}'.`);
            return value.toString();
        }
        return v;
    }
}
