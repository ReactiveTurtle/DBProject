import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../shared/product.service';
import {IProductPreset} from '../shared/product-preset.interface';
import {ProductFormComponent} from '../shared/product-form/product-form.component';

@Component({
    selector: 'rt-update-product-page',
    templateUrl: './update-product-page.component.html',
    styleUrls: ['./update-product-page.component.scss'],
    providers: [ProductService]
})
export class UpdateProductPageComponent implements OnInit {
    @ViewChild('productForm') private productForm: ProductFormComponent;
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

    public upsert(): void {
        if (this.productForm.form.invalid) {
            this.productForm.form.markAllAsTouched();
            return;
        }
        this.productService.updateProduct(this.getProductId(), this.productForm.buildUpsertCommand())
            .subscribe(() => {
                this.router.navigate(['/products', this.getProductId()]).then();
            });
    }

    private getProductId(): number {
        const routeParams = this.route.snapshot.paramMap;
        return Number(routeParams.get('productId'));
    }
}
