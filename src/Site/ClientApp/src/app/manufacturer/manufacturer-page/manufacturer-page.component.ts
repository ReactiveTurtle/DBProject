import {Component, OnInit} from '@angular/core';
import {ManufacturerService} from '../shared/manufacturer.service';
import {IManufacturerPreset} from '../shared/manufacturer-preset.interface';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
    selector: 'rt-manufacturer-page',
    templateUrl: './manufacturer-page.component.html',
    styleUrls: ['./manufacturer-page.component.scss'],
    providers: [ManufacturerService]
})
export class ManufacturerPageComponent implements OnInit {
    public manufacturerPreset: IManufacturerPreset;

    public constructor(
        private route: ActivatedRoute,
        private router: Router,
        private manufacturerService: ManufacturerService) {
    }

    public ngOnInit(): void {
        this.manufacturerService.getManufacturer(this.getManufacturerId())
            .subscribe((manufacturerPreset: IManufacturerPreset) => {
                this.manufacturerPreset = manufacturerPreset;
            });
    }

    public delete() {
        this.manufacturerService.deleteManufacturer(this.getManufacturerId())
            .subscribe(() => {
                this.router.navigate(['/manufacturers']).then();
            });
    }

    private getManufacturerId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('manufacturerId'));
    }
}
