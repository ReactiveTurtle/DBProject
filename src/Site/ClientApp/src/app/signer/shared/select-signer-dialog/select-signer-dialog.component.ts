import {Component} from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {ISignerPreset} from '../signer-preset.interface';

@Component({
    selector: 'rt-select-signer-dialog',
    templateUrl: './select-signer-dialog.component.html',
    styleUrls: ['./select-signer-dialog.component.scss']
})

export class SelectSignerDialogComponent {
    public constructor(public dialogRef: MatDialogRef<SelectSignerDialogComponent>) {
    }

    public selected(signerPreset: ISignerPreset): void {
        this.dialogRef.close(signerPreset);
    }
}
