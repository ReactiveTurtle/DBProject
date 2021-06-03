import {Component, OnInit} from '@angular/core';
import {ManufacturerService} from '../shared/manufacturer.service';
import {IManufacturerPreset} from "../shared/manufacturer-preset.interface";
import {ActivatedRoute} from "@angular/router";

@Component({
    selector: 'manufacturer-page',
    templateUrl: './manufacturer-page.component.html',
    styleUrls: ['./manufacturer-page.component.scss'],
    providers: [ManufacturerService]
})
export class ManufacturerPageComponent implements OnInit {
    public manufacturerPreset: IManufacturerPreset;

    public constructor(
        private route: ActivatedRoute,
        private manufacturerService: ManufacturerService) {
    }

    public ngOnInit(): void {
        this.manufacturerService.getManufacturer(this.getManufacturerId())
            .subscribe((manufacturerPreset: IManufacturerPreset) => {
                this.manufacturerPreset = manufacturerPreset;
            });
    }

    private getManufacturerId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('manufacturerId'));
    }
}
