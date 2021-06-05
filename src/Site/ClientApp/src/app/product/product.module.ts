import {NgModule} from '@angular/core';
import {ProductListPageComponent} from './product-list-page/product-list-page.component';
import {RouterModule} from '@angular/router';
import {CommonModule} from '@angular/common';
import {CurrencyTypePipe} from './shared/currency-type.pipe';
import {CreateProductPageComponent} from './create-product-page/create-product-page.component';
import {ProductFormComponent} from './shared/product-form/product-form.component';
import {ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {ManufacturerModule} from '../manufacturer/manufacturer.module';
import {ProductRoutingModule} from './product-routing.module';
import {ProductPageComponent} from './product-page/product-page.component';
import {UpdateProductPageComponent} from './update-product-page/update-product-page.component';
import {ProductListComponent} from './shared/product-list/product-list.component';
import {SelectProductDialogComponent} from './shared/select-product-dialog/select-product-dialog.component';
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
    declarations: [
        CurrencyTypePipe,
        ProductListComponent,
        ProductListPageComponent,
        ProductFormComponent,
        CreateProductPageComponent,
        ProductPageComponent,
        UpdateProductPageComponent,
        SelectProductDialogComponent
    ],
    imports: [
        RouterModule,
        CommonModule,
        ReactiveFormsModule,
        SharedModule,
        ManufacturerModule,
        ProductRoutingModule,
        MatDialogModule
    ],
    exports: [
        SelectProductDialogComponent,
        CurrencyTypePipe
    ],
    providers: [
        CurrencyTypePipe
    ]
})

export class ProductModule {
}
