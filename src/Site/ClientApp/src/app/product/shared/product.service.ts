import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {BaseSearchPattern} from '../../shared/base-search-pattern';
import {ISearchResult} from '../../shared/search-result.interface';
import {IProductPreset} from './product-preset.interface';
import {IUpsertProductCommand} from './upsert-product-command.interface';

@Injectable()
export class ProductService {
    private readonly productApiUrl;

    constructor(private http: HttpClient) {
        this.productApiUrl = `${environment.apiUrl}/v1/products`;
    }

    public getProduct(id: number): Observable<IProductPreset> {
        return this.http.get<IProductPreset>(
            `${this.productApiUrl}/${id}`);
    }

    public searchProducts(searchPattern: BaseSearchPattern): Observable<ISearchResult<IProductPreset>> {
        return this.http.post<ISearchResult<IProductPreset>>(
            `${this.productApiUrl}/search`,
            searchPattern);
    }

    public createProduct(upsertCommand: IUpsertProductCommand): Observable<number> {
        return this.http.post<number>(
            `${this.productApiUrl}/create`,
            upsertCommand);
    }

    public updateProduct(
        productId: number,
        upsertCommand: IUpsertProductCommand): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.productApiUrl}/${productId}/update`,
            upsertCommand);
    }

    public deleteProduct(productId: number): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.productApiUrl}/${productId}/delete`,
            {});
    }
}
