import {BrowserModule} from '@angular/platform-browser';
import {LOCALE_ID, NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {AppRoutingModule} from './app-routing.module';
import {registerLocaleData} from '@angular/common';
import localeRu from '@angular/common/locales/ru';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ManufacturerModule} from './manufacturer/manufacturer.module';
import {MatToolbarModule} from '@angular/material/toolbar';
import {HomeModule} from './home/home.module';
import {ProductModule} from './product/product.module';
import {SignerModule} from './signer/signer.module';
import {InvoiceModule} from './invoice/invoice.module';

registerLocaleData(localeRu);

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        RouterModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        HomeModule,
        ManufacturerModule,
        ProductModule,
        SignerModule,
        InvoiceModule,
        AppRoutingModule
    ],
    providers: [
        {provide: LOCALE_ID, useValue: 'ru'}
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}
