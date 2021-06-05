import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {ProductListPageComponent} from './product-list-page/product-list-page.component';
import {CreateProductPageComponent} from './create-product-page/create-product-page.component';
import {ProductPageComponent} from './product-page/product-page.component';
import {UpdateProductPageComponent} from './update-product-page/update-product-page.component';

const routes: Routes = [
    {
        path: 'products',
        component: ProductListPageComponent
    },
    {
        path: 'products/create',
        component: CreateProductPageComponent
    },
    {
        path: 'products/:productId',
        component: ProductPageComponent
    },
    {
        path: 'products/:productId/update',
        component: UpdateProductPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductRoutingModule {
}
