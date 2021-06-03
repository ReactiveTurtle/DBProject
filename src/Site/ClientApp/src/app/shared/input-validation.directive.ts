import {Directive, ElementRef} from '@angular/core';

@Directive({
    selector: '[inputValidate]'
})
export class InputValidationDirective {
    constructor(el: ElementRef) {
        el.nativeElement.addEventListener('blur', e => {
            if (e.target.type !== 'text' && e.target.type !== 'number') {
                return;
            }
            if (e.target.hasAttribute('ng-invalid')) {
                e.target.classList.add('invalid');
            } else if (e.target.hasAttribute('ng-valid')) {
                e.target.classList.add('valid');
            }
        });
    }
}
