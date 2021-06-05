import {Component} from '@angular/core';
import {IManufacturerPreset} from '../shared/manufacturer-preset.interface';
import {Router} from '@angular/router';

@Component({
    selector: 'rt-manufacturer-list-page',
    templateUrl: './manufacturer-list-page.component.html',
    styleUrls: ['./manufacturer-list-page.component.scss']
})
export class ManufacturerListPageComponent {
    public constructor(private router: Router) {
    }

    public goToManufacturerPage(manufacturerPreset: IManufacturerPreset): void {
        this.router.navigate(['/manufacturers', manufacturerPreset.id]).then();
    }
}
