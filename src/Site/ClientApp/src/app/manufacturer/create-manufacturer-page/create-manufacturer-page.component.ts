import {Component, OnInit, ViewChild} from '@angular/core';
import {ManufacturerService} from '../shared/manufacturer.service';
import {ManufacturerFormComponent} from '../shared/manufacturer-form/manufacturer-form.component';
import {Router} from '@angular/router';

@Component({
    selector: 'create-manufacturer-page',
    templateUrl: './create-manufacturer-page.component.html',
    styleUrls: ['./create-manufacturer-page.component.scss'],
    providers: [ManufacturerService]
})
export class CreateManufacturerPageComponent implements OnInit {
    @ViewChild('manufacturerForm') private manufacturerForm: ManufacturerFormComponent;

    public constructor(
        private router: Router,
        private manufacturerService: ManufacturerService) {
    }

    public ngOnInit(): void {
    }

    public upsert(): void {
        if (this.manufacturerForm.form.invalid) {
            this.manufacturerForm.form.markAllAsTouched();
            return;
        }
        this.manufacturerService.createManufacturer(this.manufacturerForm.buildUpsertCommand())
            .subscribe((id: number) => {
                this.router.navigate(['/manufacturers', id]).then();
            });
    }
}
