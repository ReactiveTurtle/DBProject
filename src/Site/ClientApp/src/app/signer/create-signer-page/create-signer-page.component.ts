import {Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {SignerService} from '../shared/signer.service';
import {SignerFormComponent} from '../shared/signer-form/signer-form.component';

@Component({
    selector: 'rt-create-signer-page',
    templateUrl: './create-signer-page.component.html',
    styleUrls: ['./create-signer-page.component.scss'],
    providers: [SignerService]
})
export class CreateSignerPageComponent implements OnInit {
    @ViewChild('signerForm') private signerForm: SignerFormComponent;
    public isQueryHandled = true;

    public constructor(
        private router: Router,
        private signerService: SignerService) {
    }

    public ngOnInit(): void {
    }

    public upsert(): void {
        if (this.signerForm.form.invalid) {
            this.signerForm.form.markAllAsTouched();
            return;
        }
        this.isQueryHandled = false;
        this.signerService.createSigner(this.signerForm.buildUpsertCommand())
            .subscribe((id: number) => {
                this.isQueryHandled = true;
                this.router.navigate(['/signers', id]).then();
            });
    }
}
