import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, ValidationErrors, Validators} from '@angular/forms';
import {IProductPreset} from '../product-preset.interface';
import {IUpsertProductCommand} from '../upsert-product-command.interface';
import {IManufacturerPreset} from '../../../manufacturer/shared/manufacturer-preset.interface';
import {SelectOption} from '../../../shared/select-option.model';
import {CurrencyType} from '../currency-type.enum';
import {SelectHelper} from '../../../shared/select-helper';
import {CurrencyTypePipe} from '../currency-type.pipe';
import {MatDialog} from '@angular/material/dialog';
import {SelectManufacturerDialogComponent} from '../../../manufacturer/shared/select-manufacturer-dialog/select-manufacturer-dialog.component';
import {DateExtensions} from '../../../shared/date-extensions';

@Component({
    selector: 'rt-product-form',
    templateUrl: './product-form.component.html'
})
export class ProductFormComponent implements OnInit {

    public constructor(public dialog: MatDialog) {
    }

    @Input()
    public productPreset: IProductPreset;

    public form: FormGroup;

    public currencyTypeSelectOptions: SelectOption[] =
        SelectHelper.enumToSelectOptions(CurrencyType, new CurrencyTypePipe());

    private manufacturerPreset: IManufacturerPreset;

    private static dateRangeValidator(formGroup: FormGroup): ValidationErrors {
        const isDateRangeValid = formGroup.get('manufactureDateTime').value > formGroup.get('expirationDateTime').value;
        if (isDateRangeValid) {
            return {dateRange: true};
        }
        return null;
    }

    public ngOnInit(): void {
        this.form = this.buildFormGroup();
        this.manufacturerControl.disable();
        if (this.manufacturerControl.value) {
            this.manufacturerControl.markAsDirty();
        }
        if (this.nameControl.value) {
            this.nameControl.markAsDirty();
        }
        if (this.priceControl.value) {
            this.priceControl.markAsDirty();
        }
        if (this.currencyTypeControl.value) {
            this.currencyTypeControl.markAsDirty();
        }
        if (this.manufactureDateTimeControl.value) {
            this.manufactureDateTimeControl.markAsDirty();
        }
        if (this.expirationDateTimeControl.value) {
            this.expirationDateTimeControl.markAsDirty();
        }
    }

    public openDialog(): void {
        const dialogRef = this.dialog.open(SelectManufacturerDialogComponent, {
            width: 'fit-content'
        });

        dialogRef.afterClosed().subscribe((manufacturerPreset: IManufacturerPreset) => {
            if (manufacturerPreset) {
                this.manufacturerPreset = manufacturerPreset;
                this.manufacturerControl.setValue(
                    `${manufacturerPreset.manufacturer.name}`
                    + ` (${manufacturerPreset.manufacturer.address})`);
                this.manufacturerControl.updateValueAndValidity();
                this.manufacturerControl.markAsDirty();
                this.manufacturerControl.markAsTouched();
            }
        });
    }

    public buildUpsertCommand(): IUpsertProductCommand {
        return {
            manufacturerId: this.manufacturerPreset?.id,
            name: this.nameControl.value,
            price: this.priceControl.value,
            currencyType: this.currencyTypeControl.value,
            manufactureDateTime: this.manufactureDateTimeControl.value,
            expirationDateTime: this.expirationDateTimeControl.value
        };
    }

    private buildFormGroup(): FormGroup {
        const manufacturer = this.productPreset?.manufacturerPreset.manufacturer;
        const manufacturerInfo = manufacturer
            ? `${manufacturer.name}` + ` (${manufacturer.address})`
            : null;
        return new FormGroup({
            manufacturer: new FormControl(manufacturerInfo, Validators.required),
            name: new FormControl(this.productPreset?.product.name, Validators.required),
            price: new FormControl(this.productPreset?.product.price, Validators.required),
            currencyType: new FormControl(this.productPreset?.product.currencyType, Validators.required),
            dateRangeGroup: new FormGroup({
                manufactureDateTime: new FormControl(
                    DateExtensions.getDate(this.productPreset?.product.manufactureDateTime),
                    Validators.required),
                expirationDateTime: new FormControl(
                    DateExtensions.getDate(this.productPreset?.product.expirationDateTime),
                    Validators.required)
            }, ProductFormComponent.dateRangeValidator)
        });
    }

    get manufacturerControl(): AbstractControl {
        return this.form.get('manufacturer');
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }

    get priceControl(): AbstractControl {
        return this.form.get('price');
    }

    get currencyTypeControl(): AbstractControl {
        return this.form.get('currencyType');
    }

    get dateRangeGroup(): FormGroup {
        return this.form.get('dateRangeGroup') as FormGroup;
    }

    get manufactureDateTimeControl(): AbstractControl {
        return this.form.get('manufactureDateTime');
    }

    get expirationDateTimeControl(): AbstractControl {
        return this.form.get('expirationDateTime');
    }
}
