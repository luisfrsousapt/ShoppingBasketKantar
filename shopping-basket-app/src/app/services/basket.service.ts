import { Injectable } from '@angular/core';
import { Product } from '../model/product.model';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class BasketService {



  constructor(private storageService:StorageService) {  }

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
