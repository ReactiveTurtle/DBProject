import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {IInvoice} from '../shared/invoice.interface';

@Component({
    selector: 'rt-invoice-list-page',
    templateUrl: './invoice-list-page.component.html',
    styleUrls: ['./invoice-list-page.component.scss']
})
export class InvoiceListPageComponent {
    public constructor(private router: Router) {
    }

    public goToInvoicePage(invoice: IInvoice): void {
        this.router.navigate(['/invoices', invoice.id]).then();
    }
}
