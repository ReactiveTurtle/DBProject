import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../shared/product.service';
import {IProductPreset} from '../shared/product-preset.interface';

@Component({
    selector: 'rt-product-page',
    templateUrl: './product-page.component.html',
    styleUrls: ['./product-page.component.scss'],
    providers: [ProductService]
})
export class ProductPageComponent implements OnInit {
    public productPreset: IProductPreset;

    public constructor(
        private route: ActivatedRoute,
        private router: Router,
        private productService: ProductService) {
    }

    public ngOnInit(): void {
        this.productService.getProduct(this.getProductId())
            .subscribe((productPreset: IProductPreset) => {
                this.productPreset = productPreset;
            });
    }

    public delete() {
        this.productService.deleteProduct(this.getProductId())
            .subscribe(() => {
                this.router.navigate(['/products']).then();
            });
    }

    private getProductId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('productId'));
    }
}
