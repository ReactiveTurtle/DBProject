import {NgModule} from '@angular/core';
import {InputValidationDirective} from './input-validation.directive';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';

@NgModule({
    declarations: [
        InputValidationDirective,
        PageNotFoundComponent
    ],
    imports: [],
    exports: [InputValidationDirective],
    providers: []
})

export class SharedModule {
}
