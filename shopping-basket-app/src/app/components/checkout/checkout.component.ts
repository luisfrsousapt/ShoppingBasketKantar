import { Component } from '@angular/core';
import { Product } from 'src/app/model/product.model';
import { BasketProduct } from 'src/app/model/basketproduct.model';
import { BasketService } from 'src/app/services/basket.service';
import { StorageService } from 'src/app/services/storage.service';
import { Basket } from 'src/app/model/basket.model';
import { ReceiptService } from 'src/app/services/receipt.service';
import { ToastrService } from 'ngx-toastr';
import { shoppingAppGlobals } from 'src/app/model/globals';
import { Router } from '@angular/router';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {
  basketProducts:Product[] = []
  basket:Basket


  constructor(private basketService: BasketService, private receiptService: ReceiptService, private toastr: ToastrService, private storage: StorageService, private router: Router){

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
        console.log(this.basket)
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

  checkoutBasket(){
    this.receiptService.getReceipt(this.basket).subscribe({
      next: (blob: Blob) => {
        const url = window.URL.createObjectURL(blob);
        saveAs(blob, 'receipt.pdf');
        window.URL.revokeObjectURL(url);
        this.toastr.success('Purchase successful!', 'Shopping Cart', shoppingAppGlobals.toastOptions)
        this.storage.removeItem("basket")
        this.router.navigate(["/"])

      },
      error: (error: any) => {
        console.error('Error fetching basket:', error);
        this.toastr.error('Error trying to purchase the order', 'Shopping Cart', shoppingAppGlobals.toastOptions)
      },
      complete: () => {
        console.log('Request completed');
      }
    });
  }
}
