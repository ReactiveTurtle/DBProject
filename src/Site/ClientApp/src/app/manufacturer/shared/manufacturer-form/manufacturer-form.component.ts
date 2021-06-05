import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {IUpsertManufacturerCommand} from '../upsert-manufacturer-command.interface';
import {IManufacturerPreset} from '../manufacturer-preset.interface';

@Component({
    selector: 'rt-manufacturer-form',
    templateUrl: './manufacturer-form.component.html'
})
export class ManufacturerFormComponent implements OnInit {
    @Input()
    public manufacturerPreset: IManufacturerPreset;

    public form: FormGroup;

    public ngOnInit(): void {
        this.form = this.buildFormGroup()
        if (this.nameControl.value) {
            this.nameControl.markAsDirty();
        }
        if (this.addressControl.value) {
            this.addressControl.markAsDirty();
        }
        if (this.phoneNumberControl.value) {
            this.phoneNumberControl.markAsDirty();
        }
        if (this.emailControl.value) {
            this.emailControl.markAsDirty();
        }
        if (this.managerFullnameControl.value) {
            this.managerFullnameControl.markAsDirty();
        }
    }

    public buildUpsertCommand(): IUpsertManufacturerCommand {
        return {
            name: this.nameControl.value,
            address: this.addressControl.value,
            phoneNumber: this.phoneNumberControl.value,
            email: this.emailControl.value,
            managerFullname: this.managerFullnameControl.value
        };
    }

    private buildFormGroup(): FormGroup {
        return new FormGroup({
            name: new FormControl(this.manufacturerPreset?.manufacturer.name, Validators.required),
            address: new FormControl(this.manufacturerPreset?.manufacturer.address, Validators.required),
            phoneNumber: new FormControl(this.manufacturerPreset?.manufacturer.phoneNumber, Validators.required),
            email: new FormControl(this.manufacturerPreset?.manufacturer.email, Validators.required),
            managerFullname: new FormControl(this.manufacturerPreset?.manufacturer.managerFullname, Validators.required),
        });
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }

    get addressControl(): AbstractControl {
        return this.form.get('address');
    }

    get phoneNumberControl(): AbstractControl {
        return this.form.get('phoneNumber');
    }

    get emailControl(): AbstractControl {
        return this.form.get('email');
    }

    get managerFullnameControl(): AbstractControl {
        return this.form.get('managerFullname');
    }
}
