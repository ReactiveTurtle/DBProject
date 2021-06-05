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
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {ManufacturerListComponent} from './shared/manufacturer-list/manufacturer-list.component';
import {SelectManufacturerDialogComponent} from './shared/select-manufacturer-dialog/select-manufacturer-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';

@NgModule({
    declarations: [
        ManufacturerFormComponent,
        ManufacturerListPageComponent,
        CreateManufacturerPageComponent,
        UpdateManufacturerPageComponent,
        ManufacturerPageComponent,
        ManufacturerListComponent,
        SelectManufacturerDialogComponent
    ],
    imports: [
        HttpClientModule,
        ManufacturerRoutingModule,
        CommonModule,
        MatButtonModule,
        MatTableModule,
        ReactiveFormsModule,
        SharedModule,
        MatProgressSpinnerModule,
        MatDialogModule
    ],
    exports: [
        SelectManufacturerDialogComponent
    ],
    providers: []
})

export class ManufacturerModule {
}
