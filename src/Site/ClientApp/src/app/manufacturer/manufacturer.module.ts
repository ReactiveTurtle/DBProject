import {NgModule} from '@angular/core';
import {ManufacturerListPageComponent} from './manufactuer-list-page/manufacturer-list-page.component';
import {ManufacturerRoutingModule} from './manufacturer-routing.module';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {CreateManufacturerPageComponent} from './create-manufacturer-page/create-manufacturer-page.component';
import {ReactiveFormsModule} from '@angular/forms';
import {ManufacturerFormComponent} from './shared/manufacturer-form/manufacturer-form.component';
import {SharedModule} from '../shared/shared.module';
import {UpdateManufacturerPageComponent} from './update-manufacturer-page/update-manufacturer-page.component';
import {ManufacturerPageComponent} from './manufacturer-page/manufacturer-page.component';

@NgModule({
    declarations: [
        ManufacturerFormComponent,
        ManufacturerListPageComponent,
        CreateManufacturerPageComponent,
        UpdateManufacturerPageComponent,
        ManufacturerPageComponent
    ],
    imports: [
        HttpClientModule,
        ManufacturerRoutingModule,
        CommonModule,
        MatButtonModule,
        MatTableModule,
        ReactiveFormsModule,
        SharedModule
    ],
    providers: []
})

export class ManufacturerModule {
}
