import {Component} from '@angular/core';
import {IProductPreset} from '../shared/product-preset.interface';
import {Router} from '@angular/router';

@Component({
    selector: 'rt-product-list-page',
    templateUrl: './product-list-page.component.html',
    styleUrls: ['./product-list-page.component.scss']
})
export class ProductListPageComponent {
    public constructor(private router: Router) {
    }

    public goToProductPage(productPreset: IProductPreset): void {
        this.router.navigate(['/products', productPreset.id]).then();
    }
}
