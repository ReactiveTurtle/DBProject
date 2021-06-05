import {Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {ProductService} from '../shared/product.service';
import {ProductFormComponent} from '../shared/product-form/product-form.component';

@Component({
    selector: 'rt-create-product-page',
    templateUrl: './create-product-page.component.html',
    styleUrls: ['./create-product-page.component.scss'],
    providers: [ProductService]
})
export class CreateProductPageComponent implements OnInit {
    @ViewChild('productForm') private productForm: ProductFormComponent;
    public isQueryHandled = true;

    public constructor(
        private router: Router,
        private productService: ProductService) {
    }

    public ngOnInit(): void {
    }

    public upsert(): void {
        if (this.productForm.form.invalid) {
            this.productForm.form.markAllAsTouched();
            return;
        }
        this.isQueryHandled = false;
        this.productService.createProduct(this.productForm.buildUpsertCommand())
            .subscribe((id: number) => {
                this.isQueryHandled = true;
                this.router.navigate(['/products', id]).then();
            });
    }
}
