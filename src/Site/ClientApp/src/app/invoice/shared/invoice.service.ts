import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {BaseSearchPattern} from '../../shared/base-search-pattern';
import {ISearchResult} from '../../shared/search-result.interface';
import {IInvoice} from './invoice.interface';
import {IUpsertInvoiceCommand} from './upsert-invoice-command.interface';

@Injectable()
export class InvoiceService {
    private readonly productApiUrl;

    constructor(private http: HttpClient) {
        this.productApiUrl = `${environment.apiUrl}/v1/invoices`;
    }

    public getInvoice(id: number): Observable<IInvoice> {
        return this.http.get<IInvoice>(
            `${this.productApiUrl}/${id}`);
    }

    public searchInvoices(searchPattern: BaseSearchPattern): Observable<ISearchResult<IInvoice>> {
        return this.http.post<ISearchResult<IInvoice>>(
            `${this.productApiUrl}/search`,
            searchPattern);
    }

    public createInvoice(upsertCommand: IUpsertInvoiceCommand): Observable<number> {
        return this.http.post<number>(
            `${this.productApiUrl}/create`,
            upsertCommand);
    }

    public deleteInvoice(productId: number): Observable<ArrayBuffer[]> {
        return this.http.post<ArrayBuffer[]>(
            `${this.productApiUrl}/${productId}/delete`,
            {});
    }
}
