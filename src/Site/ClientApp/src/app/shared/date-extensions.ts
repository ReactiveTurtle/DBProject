export class DateExtensions {
    public static getDate(date: Date): string {
        return date?.toString().substr(0, 10);
    }
}
