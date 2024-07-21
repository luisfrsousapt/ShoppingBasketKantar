import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Product } from 'src/app/model/product.model';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.scss']
})
export class ItemCardComponent {
  @Input() product: Product
  @Output() productChange: EventEmitter<Product> = new EventEmitter<Product>();

  itemQuantity: number = 1;

  sendToBasket(){
    this.product.quantity = this.itemQuantity;
    this.productChange.emit(this.product)
  }
}
