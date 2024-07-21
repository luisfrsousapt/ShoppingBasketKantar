import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { shoppingAppGlobals } from 'src/app/model/globals';
import { Product } from 'src/app/model/product.model';
import { BasketService } from 'src/app/services/basket.service';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent {

  trendingProducts: Product[] = [];

  constructor(private productService: ProductsService,
    private basketService: BasketService,
    private toastr: ToastrService
  ){}
  

  ngOnInit(){
   this.loadTrendingProducts();
  }

  loadTrendingProducts(): void {
    this.productService.getTrendingProducts().subscribe(data => {
      this.trendingProducts = data;
    });
  }

  saveProductInBasket(p : Product){
    this.basketService.saveInBasket(p);
    this.toastr.success('Successfully added to the cart!', 'Shopping Cart', shoppingAppGlobals.toastOptions)
  }
}
