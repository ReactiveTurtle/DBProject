import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {CreateSignerPageComponent} from './create-signer-page/create-signer-page.component';
import {SignerListPageComponent} from './signer-list-page/signer-list-page.component';
import {SignerPageComponent} from './signer-page/signer-page.component';
import {UpdateSignerPageComponent} from './update-signer-page/update-signer-page.component';

const routes: Routes = [
    {
        path: 'signers',
        component: SignerListPageComponent
    },
    {
        path: 'signers/create',
        component: CreateSignerPageComponent
    },
    {
        path: 'signers/:signerId',
        component: SignerPageComponent
    },
    {
        path: 'signers/:signerId/update',
        component: UpdateSignerPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SignerRoutingModule {
}
