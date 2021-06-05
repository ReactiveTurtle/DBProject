import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {SignerService} from '../shared/signer.service';
import {ISignerPreset} from '../shared/signer-preset.interface';

@Component({
    selector: 'rt-signer-page',
    templateUrl: './signer-page.component.html',
    styleUrls: ['./signer-page.component.scss'],
    providers: [SignerService]
})
export class SignerPageComponent implements OnInit {
    public signerPreset: ISignerPreset;

    public constructor(
        private route: ActivatedRoute,
        private router: Router,
        private signerService: SignerService) {
    }

    public ngOnInit(): void {
        this.signerService.getSigner(this.getSignerId())
            .subscribe((signerPreset: ISignerPreset) => {
                this.signerPreset = signerPreset;
            });
    }

    public delete() {
        this.signerService.deleteSigner(this.getSignerId())
            .subscribe(() => {
                this.router.navigate(['/signers']).then();
            });
    }

    private getSignerId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('signerId'));
    }
}
