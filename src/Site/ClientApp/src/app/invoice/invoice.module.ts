import {NgModule} from '@angular/core';
import {InvoiceRoutingModule} from './invoice-routing.module';
import {CreateInvoicePageComponent} from './create-invoice-page/create-invoice-page.component';
import {ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {CommonModule} from '@angular/common';
import {InvoiceListPageComponent} from './invoice-list-page/invoice-list-page.component';
import {InvoiceListComponent} from './shared/invoice-list/invoice-list.component';
import {InvoicePageComponent} from './invoice-page/invoice-page.component';
import {ProductModule} from '../product/product.module';

@NgModule({
    declarations: [
        InvoiceListComponent,
        InvoiceListPageComponent,
        CreateInvoicePageComponent,
        InvoicePageComponent
    ],
    imports: [
        InvoiceRoutingModule,
        ReactiveFormsModule,
        SharedModule,
        MatProgressSpinnerModule,
        CommonModule,
        ProductModule
    ],
    providers: []
})

export class InvoiceModule {
}
