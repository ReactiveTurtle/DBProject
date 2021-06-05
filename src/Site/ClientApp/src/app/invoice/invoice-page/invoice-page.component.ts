import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {IInvoice} from '../shared/invoice.interface';
import {InvoiceService} from '../shared/invoice.service';

@Component({
    selector: 'rt-invoice-page',
    templateUrl: './invoice-page.component.html',
    styleUrls: ['./invoice-page.component.scss'],
    providers: [InvoiceService]
})
export class InvoicePageComponent implements OnInit {
    public invoice: IInvoice;

    public constructor(
        private route: ActivatedRoute,
        private router: Router,
        private invoiceService: InvoiceService) {
    }

    public ngOnInit(): void {
        this.invoiceService.getInvoice(this.getInvoiceId())
            .subscribe((invoice: IInvoice) => {
                console.log(invoice);
                this.invoice = invoice;
            });
    }

    public delete() {
        this.invoiceService.deleteInvoice(this.getInvoiceId())
            .subscribe(() => {
                this.router.navigate(['/invoices']).then();
            });
    }

    private getInvoiceId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('invoiceId'));
    }
}
