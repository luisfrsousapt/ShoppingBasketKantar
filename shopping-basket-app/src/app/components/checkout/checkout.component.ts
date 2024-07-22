import { Component } from '@angular/core';
import { Product } from 'src/app/model/product.model';
import { BasketProduct } from 'src/app/model/basketproduct.model';
import { BasketService } from 'src/app/services/basket.service';
import { StorageService } from 'src/app/services/storage.service';
import { Basket } from 'src/app/model/basket.model';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {
  basketProducts:Product[] = []
  basket:Basket


  constructor(private basketService: BasketService){

  }

  ngOnInit(){
    this.basketProducts = this.basketService.getBasketProducts()
    this.getCheckoutValues()
  }

  getCheckoutValues(){
    let products: BasketProduct[] = []
    if(this.basketProducts){

    this.basketProducts.forEach( p => {
      let product = <BasketProduct>{productId: p.productExternalId, productQuantity:p.quantity}
      products.push(product)
    })
    this.basketService.getBasket(products).subscribe({
      next: (basket: Basket) => {
        this.basket = basket
      },
      error: (error: any) => {
        console.error('Error fetching basket:', error);
      },
      complete: () => {
        console.log('Request completed');
      }
    });
  } else{
    this.basket.discountsValue = 0
    this.basket.subtotalValue = 0
    this.basket.totalValue = 0
  }
  }

  removeFromCart(p :Product){
    this.basketService.removeFromCart(p);
    this.basketProducts = this.basketService.getBasketProducts()
    this.getCheckoutValues()
  }
}
