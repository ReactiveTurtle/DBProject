import {Component, OnInit, ViewChild} from '@angular/core';
import {ManufacturerService} from '../shared/manufacturer.service';
import {ManufacturerFormComponent} from '../shared/manufacturer-form/manufacturer-form.component';
import {ActivatedRoute, Router} from '@angular/router';
import {IManufacturerPreset} from '../shared/manufacturer-preset.interface';

@Component({
    selector: 'update-manufacturer-page',
    templateUrl: './update-manufacturer-page.component.html',
    styleUrls: ['./update-manufacturer-page.component.scss'],
    providers: [ManufacturerService]
})
export class UpdateManufacturerPageComponent implements OnInit {
    @ViewChild('manufacturerForm') private manufacturerForm: ManufacturerFormComponent;
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

    public upsert(): void {
        if (this.manufacturerForm.form.invalid) {
            this.manufacturerForm.form.markAllAsTouched();
            return;
        }
        this.manufacturerService.updateManufacturer(this.getManufacturerId(), this.manufacturerForm.buildUpsertCommand())
            .subscribe(() => {
                this.router.navigate(['/manufacturers', this.getManufacturerId()]).then();
            });
    }

    private getManufacturerId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('manufacturerId'));
    }
}
