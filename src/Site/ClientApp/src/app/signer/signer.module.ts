import {NgModule} from '@angular/core';
import {SignerRoutingModule} from './signer-routing.module';
import {SignerFormComponent} from './shared/signer-form/signer-form.component';
import {ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {CommonModule} from '@angular/common';
import {CreateSignerPageComponent} from './create-signer-page/create-signer-page.component';
import {SignerListComponent} from './shared/signer-list/signer-list.component';
import {SignerListPageComponent} from './signer-list-page/signer-list-page.component';
import {SignerPageComponent} from './signer-page/signer-page.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {UpdateSignerPageComponent} from './update-signer-page/update-signer-page.component';
import {SelectSignerDialogComponent} from './shared/select-signer-dialog/select-signer-dialog.component';

@NgModule({
    declarations: [
        SignerFormComponent,
        SignerListComponent,
        SignerListPageComponent,
        CreateSignerPageComponent,
        SignerPageComponent,
        UpdateSignerPageComponent,
        SelectSignerDialogComponent
    ],
    imports: [
        SignerRoutingModule,
        ReactiveFormsModule,
        SharedModule,
        CommonModule,
        MatProgressSpinnerModule
    ],
    exports: [
        SelectSignerDialogComponent
    ],
    providers: []
})

export class SignerModule {
}
