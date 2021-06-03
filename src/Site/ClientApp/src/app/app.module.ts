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

registerLocaleData(localeRu);

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        RouterModule,
        BrowserAnimationsModule,
        ManufacturerModule,
        MatToolbarModule
    ],
    providers: [
        {provide: LOCALE_ID, useValue: 'ru'}
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
}
