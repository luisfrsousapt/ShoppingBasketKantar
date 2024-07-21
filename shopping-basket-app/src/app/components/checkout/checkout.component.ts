import { Component } from '@angular/core';
import { Product } from 'src/app/model/product.model';
import { BasketService } from 'src/app/services/basket.service';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {
  basketProducts:Product[] = []


  constructor(private basketService: BasketService){

  }

  ngOnInit(){
    this.basketProducts = this.basketService.getBasketProducts()
  }

  getSubTotal(){
    let subtotal = 0;
    this.basketProducts.forEach(p => {
      let productTotalValue = p.price * p.quantity
      subtotal += productTotalValue
    })
    return subtotal
  }

  removeFromCart(p :Product){
    this.basketService.removeFromCart(p);
    this.basketProducts = this.basketService.getBasketProducts()
  }
}
