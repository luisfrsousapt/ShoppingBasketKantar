import { Injectable } from '@angular/core';
import { Product } from '../model/product.model';
import { StorageService } from './storage.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Basket } from '../model/basket.model';
import { environment } from 'src/environments/environment.development';
import { BasketProduct } from '../model/basketproduct.model';
import { Discount } from '../model/discount.model';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private storageService:StorageService, private http: HttpClient) { }

  getBasket(products: BasketProduct[]): Observable<Basket> {
    return this.http.post<Basket>(`${environment.api_basket_url}/`, products);
  }

  checkDiscountCode(code:string): Observable<Discount>{
    return this.http.get<Discount>(`${environment.api_discount_url}/discountcode/${code}`);
  }

  saveInBasket(product: Product) {
    var basketProducts:Product[] = []
    if(this.storageService.getItem('basket')){
      basketProducts = <Product[]>this.storageService.getItem('basket');
    }
    basketProducts.push(product)
    this.storageService.addItem('basket',basketProducts);
  }

  getItemsCount(){
    var itemsQuantity = 0;
    var basketProducts = <Product[]>this.storageService.getItem('basket');
    if(basketProducts){
      basketProducts.forEach(p =>{
        itemsQuantity += p.quantity
      })
    }
    return itemsQuantity
  }

  getBasketProducts(){
    let basketProducts:Product[] = []
    let listOfProducts = <Product[]>this.storageService.getItem('basket');
    if (listOfProducts) {
      basketProducts = this.mergeProducts(listOfProducts);
      this.storageService.addItem('basket',basketProducts);
    }
    return basketProducts
  }

  removeFromCart(prod: Product){
    let listOfProducts = <Product[]>this.storageService.getItem('basket');
    if (listOfProducts) {
      listOfProducts = listOfProducts.filter(p => p.productExternalId != prod.productExternalId)
      this.storageService.addItem('basket',listOfProducts);
    }
  }

  changeProductQuantityCart(prod: Product) {
    let listOfProducts = <Product[]>this.storageService.getItem('basket');
    if (listOfProducts) {
        listOfProducts = listOfProducts.map(p => {
            if (p.productExternalId === prod.productExternalId) {
                return { ...p, quantity: prod.quantity }; 
            }
            return p; 
        });
        this.storageService.addItem('basket', listOfProducts);
    }
}


  mergeProducts(products: Product[]): Product[] {
    const mergedProducts: { [key: string]: Product } = {};

    products.forEach(product => {
      if (mergedProducts[product.productExternalId]) {
        mergedProducts[product.productExternalId].quantity += product.quantity;
      } else {
        mergedProducts[product.productExternalId] = { ...product };
      }
    });

    return Object.values(mergedProducts);
  }
}
