import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {SignerService} from '../shared/signer.service';
import {SignerFormComponent} from '../shared/signer-form/signer-form.component';
import {ISignerPreset} from '../shared/signer-preset.interface';

@Component({
    selector: 'rt-update-signer-page',
    templateUrl: './update-signer-page.component.html',
    styleUrls: ['./update-signer-page.component.scss'],
    providers: [SignerService]
})
export class UpdateSignerPageComponent implements OnInit {
    @ViewChild('signerForm') private signerForm: SignerFormComponent;
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

    public upsert(): void {
        if (this.signerForm.form.invalid) {
            this.signerForm.form.markAllAsTouched();
            return;
        }
        this.signerService.updateSigner(this.getSignerId(), this.signerForm.buildUpsertCommand())
            .subscribe(() => {
                this.router.navigate(['/signers', this.getSignerId()]).then();
            });
    }

    private getSignerId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('signerId'));
    }
}
