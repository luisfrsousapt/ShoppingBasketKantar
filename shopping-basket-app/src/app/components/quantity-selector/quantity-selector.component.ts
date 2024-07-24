import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-quantity-selector',
  templateUrl: './quantity-selector.component.html',
  styleUrls: ['./quantity-selector.component.scss']
})
export class QuantitySelectorComponent {
  @Input() quantity: number = 1;
  @Input() minQ: number = 1;
  @Input() maxQ: number = 100;
  @Output() quantityChange: EventEmitter<number> = new EventEmitter<number>();


  ngOnInit(){
    if(this.quantity === undefined || this.quantity === null){
      this.quantity = 1
    }
  }

  decreaseQuantity(): void {
    if (this.quantity > this.minQ) {
      this.quantity--;
      this.quantityChange.emit(this.quantity);
    }
  }

  updateQuantity(){
    if(this.quantity == 0){
      this.quantity = 1
    }
    this.quantityChange.emit(this.quantity);
  }

  increaseQuantity(): void {
    if (this.quantity < this.maxQ) {
      this.quantity++;
      this.quantityChange.emit(this.quantity);
    }
  }
}
