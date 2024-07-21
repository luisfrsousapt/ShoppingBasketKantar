import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { shoppingAppGlobals } from 'src/app/model/globals';
import { Product } from 'src/app/model/product.model';
import { BasketService } from 'src/app/services/basket.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {

  products: Product[] = []

  constructor(private productService: ProductsService,
    private basketService: BasketService,
    private toastr: ToastrService
  ){}

  ngOnInit(){
    this.loadProducts();
   }
 
   loadProducts(): void {
     this.productService.getAllProducts().subscribe(data => {
       this.products = data;
     });
   }

   saveProductInBasket(p : Product){
    this.basketService.saveInBasket(p);
    this.toastr.success('Successfully added to the cart!', 'Shopping Cart', shoppingAppGlobals.toastOptions)
  }
}
