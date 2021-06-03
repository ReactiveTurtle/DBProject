import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {ManufacturerListPageComponent} from './manufactuer-list-page/manufacturer-list-page.component';
import {CreateManufacturerPageComponent} from './create-manufacturer-page/create-manufacturer-page.component';
import {UpdateManufacturerPageComponent} from './update-manufacturer-page/update-manufacturer-page.component';
import {ManufacturerPageComponent} from './manufacturer-page/manufacturer-page.component';

const routes: Routes = [
    {
        path: 'manufacturers',
        component: ManufacturerListPageComponent
    },
    {
        path: 'manufacturers/create',
        component: CreateManufacturerPageComponent
    },
    {
        path: 'manufacturers/:manufacturerId',
        component: ManufacturerPageComponent
    },
    {
        path: 'manufacturers/:manufacturerId/update',
        component: UpdateManufacturerPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ManufacturerRoutingModule {
}
