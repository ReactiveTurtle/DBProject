import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {InvoiceService} from '../shared/invoice.service';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {IUpsertInvoiceCommand} from '../shared/upsert-invoice-command.interface';
import {ISignerPreset} from '../../signer/shared/signer-preset.interface';
import {IProductPreset} from '../../product/shared/product-preset.interface';
import {MatDialog} from '@angular/material/dialog';
import {SelectSignerDialogComponent} from '../../signer/shared/select-signer-dialog/select-signer-dialog.component';
import {SelectProductDialogComponent} from '../../product/shared/select-product-dialog/select-product-dialog.component';

@Component({
    selector: 'rt-create-invoice-page',
    templateUrl: './create-invoice-page.component.html',
    styleUrls: ['./create-invoice-page.component.scss'],
    providers: [InvoiceService]
})
export class CreateInvoicePageComponent implements OnInit {
    public form: FormGroup;

    public isQueryHandled = true;

    public productPresets: IProductPreset[] = [];

    private signerPreset: ISignerPreset;

    public constructor(
        private router: Router,
        private invoiceService: InvoiceService,
        public dialog: MatDialog) {
    }

    public ngOnInit(): void {
        this.form = this.buildFormGroup();
        this.signerControl.disable();
    }

    public openSignerDialog(): void {
        const dialogRef = this.dialog.open(SelectSignerDialogComponent, {
            width: 'fit-content'
        });

        dialogRef.afterClosed().subscribe((signerPreset: ISignerPreset) => {
            if (signerPreset) {
                this.signerPreset = signerPreset;
                this.signerControl.setValue(
                    `${signerPreset.signer.fullname}`
                    + ` (${signerPreset.signer.position}, ${signerPreset.signer.phoneNumber})`);
                this.signerControl.updateValueAndValidity();
                this.signerControl.markAsDirty();
                this.signerControl.markAsTouched();
            }
        });
    }

    public openProductDialog(): void {
        const dialogRef = this.dialog.open(SelectProductDialogComponent, {
            width: 'fit-content'
        });

        dialogRef.afterClosed().subscribe((productPreset: IProductPreset) => {
            if (productPreset) {
                this.productPresets.push(productPreset);
                if (!this.productsControl.value) {
                    this.productsControl.setValue('1');
                }
                this.productsControl.updateValueAndValidity();
                this.productsControl.markAsDirty();
                this.productsControl.markAsTouched();
            }
        });
    }

    public upsert(): void {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }
        this.isQueryHandled = false;
        this.invoiceService.createInvoice(this.buildUpsertCommand())
            .subscribe((id: number) => {
                this.isQueryHandled = true;
                this.router.navigate(['/invoices', id]).then();
            });
    }

    public buildUpsertCommand(): IUpsertInvoiceCommand {
        return {
            name: this.nameControl.value,
            preparationDate: this.preparationDateControl.value,
            signerPresetId: this.signerPreset.id,
            productPresets: this.productPresets
        };
    }

    private buildFormGroup(): FormGroup {
        return new FormGroup({
            name: new FormControl(null, Validators.required),
            preparationDate: new FormControl(null, Validators.required),
            signer: new FormControl(null, Validators.required),
            products: new FormControl(null, Validators.required)
        });
    }

    get nameControl(): AbstractControl {
        return this.form.get('name');
    }

    get preparationDateControl(): AbstractControl {
        return this.form.get('preparationDate');
    }

    get signerControl(): AbstractControl {
        return this.form.get('signer');
    }

    get productsControl(): AbstractControl {
        return this.form.get('products');
    }
}
