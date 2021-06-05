import {Component} from '@angular/core';
import {IManufacturerPreset} from '../manufacturer-preset.interface';
import {MatDialogRef} from '@angular/material/dialog';

@Component({
    selector: 'rt-select-manufacturer-dialog',
    templateUrl: './select-manufacturer-dialog.component.html',
    styleUrls: ['./select-manufacturer-dialog.component.scss']
})

export class SelectManufacturerDialogComponent {
    public constructor(public dialogRef: MatDialogRef<SelectManufacturerDialogComponent>) {
    }

    public selected(manufacturerPreset: IManufacturerPreset): void {
        this.dialogRef.close(manufacturerPreset);
    }
}
