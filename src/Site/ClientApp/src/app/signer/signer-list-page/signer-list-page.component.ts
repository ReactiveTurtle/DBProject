import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {ISignerPreset} from '../shared/signer-preset.interface';

@Component({
    selector: 'rt-signer-list-page',
    templateUrl: './signer-list-page.component.html',
    styleUrls: ['./signer-list-page.component.scss']
})
export class SignerListPageComponent {
    public constructor(private router: Router) {
    }

    public goToSignerPage(signerPreset: ISignerPreset): void {
        this.router.navigate(['/signers', signerPreset.id]).then();
    }
}
