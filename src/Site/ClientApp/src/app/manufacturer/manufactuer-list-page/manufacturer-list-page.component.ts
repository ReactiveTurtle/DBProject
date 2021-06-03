import {Component} from '@angular/core';
import {ManufacturerService} from '../shared/manufacturer.service';
import {IManufacturerPreset} from '../shared/manufacturer-preset.interface';
import {ISearchResult} from '../../shared/search-result.interface';
import {BaseSearchPattern} from '../../shared/base-search-pattern';

@Component({
    selector: 'manufacturer-list-page',
    templateUrl: './manufacturer-list-page.component.html',
    styleUrls: ['./manufacturer-list-page.component.scss'],
    providers: [ManufacturerService]
})
export class ManufacturerListPageComponent {
    public manufacturers: ISearchResult<IManufacturerPreset>;

    public constructor(private manufacturerService: ManufacturerService) {
        manufacturerService.searchManufacturers(new BaseSearchPattern(1, 10, ''))
            .subscribe(result => {
                this.manufacturers = result;
            });
    }
}
