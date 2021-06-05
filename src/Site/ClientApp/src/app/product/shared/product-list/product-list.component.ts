import {Component, EventEmitter, Output} from '@angular/core';
import {ISearchResult} from '../../../shared/search-result.interface';
import {BaseSearchPattern} from '../../../shared/base-search-pattern';
import {ProductService} from '../product.service';
import {IProductPreset} from '../product-preset.interface';

@Component({
    selector: 'rt-product-list',
    templateUrl: './product-list.component.html',
    providers: [ProductService]
})
export class ProductListComponent {
    public products: ISearchResult<IProductPreset>;

    @Output()
    public select: EventEmitter<IProductPreset> = new EventEmitter<IProductPreset>();

    public constructor(private productService: ProductService) {
        productService.searchProducts(new BaseSearchPattern(1, 10, ''))
            .subscribe(result => {
                this.products = result;
            }, (error) => {
                console.log(error);
            });
    }

    public selected(productPreset: IProductPreset): void {
        this.select.emit(productPreset);
    }
}
