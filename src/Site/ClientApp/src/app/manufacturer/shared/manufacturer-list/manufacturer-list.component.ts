import {Component, EventEmitter, Output} from '@angular/core';
import {ManufacturerService} from '../manufacturer.service';
import {ISearchResult} from '../../../shared/search-result.interface';
import {IManufacturerPreset} from '../manufacturer-preset.interface';
import {BaseSearchPattern} from '../../../shared/base-search-pattern';

@Component({
    selector: 'rt-manufacturer-list',
    templateUrl: './manufacturer-list.component.html',
    providers: [ManufacturerService]
})
export class ManufacturerListComponent {
    public manufacturers: ISearchResult<IManufacturerPreset>;

    @Output()
    public select: EventEmitter<IManufacturerPreset> = new EventEmitter<IManufacturerPreset>();

    public constructor(private manufacturerService: ManufacturerService) {
        manufacturerService.searchManufacturers(new BaseSearchPattern(1, 10, ''))
            .subscribe(result => {
                this.manufacturers = result;
            });
    }

    public selected(manufacturerPreset: IManufacturerPreset): void {
        this.select.emit(manufacturerPreset);
    }
}
