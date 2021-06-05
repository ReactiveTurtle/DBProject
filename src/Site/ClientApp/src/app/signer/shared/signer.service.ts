import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {BaseSearchPattern} from '../../shared/base-search-pattern';
import {ISearchResult} from '../../shared/search-result.interface';
import {ISignerPreset} from './signer-preset.interface';
import {IUpsertSignerCommand} from './upsert-signer-command.interface';

@Injectable()
export class SignerService {
    private readonly productApiUrl;

    constructor(private http: HttpClient) {
        this.productApiUrl = `${environment.apiUrl}/v1/signers`;
    }

    public getSigner(id: number): Observable<ISignerPreset> {
        return this.http.get<ISignerPreset>(
            `${this.productApiUrl}/${id}`);
    }

    public searchSigners(searchPattern: BaseSearchPattern): Observable<ISearchResult<ISignerPreset>> {
        return this.http.post<ISearchResult<ISignerPreset>>(
            `${this.productApiUrl}/search`,
            searchPattern);
    }

    public createSigner(upsertCommand: IUpsertSignerCommand): Observable<number> {
        return this.http.post<number>(
            `${this.productApiUrl}/create`,
            upsertCommand);
    }

    public updateSigner(
        productId: number,
        upsertCommand: IUpsertSignerCommand): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.productApiUrl}/${productId}/update`,
            upsertCommand);
    }

    public deleteSigner(productId: number): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.productApiUrl}/${productId}/delete`,
            {});
    }
}
