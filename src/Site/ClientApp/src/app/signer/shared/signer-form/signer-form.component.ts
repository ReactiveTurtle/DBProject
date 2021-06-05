import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {ISignerPreset} from '../signer-preset.interface';
import {IUpsertSignerCommand} from '../upsert-signer-command.interface';

@Component({
    selector: 'rt-signer-form',
    templateUrl: './signer-form.component.html'
})
export class SignerFormComponent implements OnInit {

    public constructor() {
    }

    @Input()
    public signerPreset: ISignerPreset;

    public form: FormGroup;

    public ngOnInit(): void {
        this.form = this.buildFormGroup();
        if (this.fullnameControl.value) {
            this.fullnameControl.markAsDirty();
        }
        if (this.positionControl.value) {
            this.positionControl.markAsDirty();
        }
        if (this.addressControl.value) {
            this.addressControl.markAsDirty();
        }
        if (this.phoneNumberControl.value) {
            this.phoneNumberControl.markAsDirty();
        }
    }

    public buildUpsertCommand(): IUpsertSignerCommand {
        return {
            fullname:  this.fullnameControl.value,
            position: this.positionControl.value,
            address: this.addressControl.value,
            phoneNumber: this.phoneNumberControl.value
        };
    }

    private buildFormGroup(): FormGroup {
        return new FormGroup({
            fullname: new FormControl(this.signerPreset?.signer.fullname, Validators.required),
            position: new FormControl(this.signerPreset?.signer.position, Validators.required),
            address: new FormControl(this.signerPreset?.signer.address, Validators.required),
            phoneNumber: new FormControl(this.signerPreset?.signer.phoneNumber, Validators.required)
        });
    }

    get fullnameControl(): AbstractControl {
        return this.form.get('fullname');
    }

    get positionControl(): AbstractControl {
        return this.form.get('position');
    }

    get addressControl(): AbstractControl {
        return this.form.get('address');
    }

    get phoneNumberControl(): AbstractControl {
        return this.form.get('phoneNumber');
    }
}
