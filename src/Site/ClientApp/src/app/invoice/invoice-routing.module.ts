import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CreateInvoicePageComponent} from './create-invoice-page/create-invoice-page.component';
import {InvoiceListPageComponent} from './invoice-list-page/invoice-list-page.component';
import {InvoicePageComponent} from './invoice-page/invoice-page.component';

const routes: Routes = [
    {
        path: 'invoices',
        component: InvoiceListPageComponent
    },
    {
        path: 'invoices/create',
        component: CreateInvoicePageComponent
    },
    {
        path: 'invoices/:invoiceId',
        component: InvoicePageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class InvoiceRoutingModule {
}
