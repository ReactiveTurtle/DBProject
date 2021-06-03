export interface ISearchResult<T> {
    readonly items: T[];
    readonly totalCount: number;
    readonly filteredCount: number;
}
