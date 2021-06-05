import {Component, EventEmitter, Output} from '@angular/core';
import {ISearchResult} from '../../../shared/search-result.interface';
import {BaseSearchPattern} from '../../../shared/base-search-pattern';
import {InvoiceService} from '../invoice.service';
import {IInvoice} from '../invoice.interface';

@Component({
    selector: 'rt-invoice-list',
    templateUrl: './invoice-list.component.html',
    providers: [InvoiceService]
})
export class InvoiceListComponent {
    public invoices: ISearchResult<IInvoice>;

    @Output()
    public select: EventEmitter<IInvoice> = new EventEmitter<IInvoice>();

    public constructor(private invoiceService: InvoiceService) {
        invoiceService.searchInvoices(new BaseSearchPattern(1, 10, ''))
            .subscribe(result => {
                this.invoices = result;
            });
    }

    public selected(invoice: IInvoice): void {
        this.select.emit(invoice);
    }
}
