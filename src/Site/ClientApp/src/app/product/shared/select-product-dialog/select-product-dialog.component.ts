import {Component} from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {IProductPreset} from '../product-preset.interface';

@Component({
    selector: 'rt-select-product-dialog',
    templateUrl: './select-product-dialog.component.html',
    styleUrls: ['./select-product-dialog.component.scss']
})

export class SelectProductDialogComponent {
    public constructor(public dialogRef: MatDialogRef<SelectProductDialogComponent>) {
    }

    public selected(productPreset: IProductPreset): void {
        this.dialogRef.close(productPreset);
    }
}
