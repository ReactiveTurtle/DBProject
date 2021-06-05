import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {IManufacturerPreset} from './manufacturer-preset.interface';
import {BaseSearchPattern} from '../../shared/base-search-pattern';
import {ISearchResult} from '../../shared/search-result.interface';
import {IUpsertManufacturerCommand} from './upsert-manufacturer-command.interface';

@Injectable()
export class ManufacturerService {
    private readonly manufacturerApiUrl;

    constructor(private http: HttpClient) {
        this.manufacturerApiUrl = `${environment.apiUrl}/v1/manufacturers`;
    }

    public getManufacturer(id: number): Observable<IManufacturerPreset> {
        return this.http.get<IManufacturerPreset>(
            `${this.manufacturerApiUrl}/${id}`);
    }

    public searchManufacturers(searchPattern: BaseSearchPattern): Observable<ISearchResult<IManufacturerPreset>> {
        return this.http.post<ISearchResult<IManufacturerPreset>>(
            `${this.manufacturerApiUrl}/search`,
            searchPattern);
    }

    public createManufacturer(upsertCommand: IUpsertManufacturerCommand): Observable<number> {
        return this.http.post<number>(
            `${this.manufacturerApiUrl}/create`,
            upsertCommand);
    }

    public updateManufacturer(
        manufacturerId: number,
        upsertCommand: IUpsertManufacturerCommand): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.manufacturerApiUrl}/${manufacturerId}/update`,
            upsertCommand);
    }

    public deleteManufacturer(manufacturerId: number): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.manufacturerApiUrl}/${manufacturerId}/delete`,
            {});
    }
}
