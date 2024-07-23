import { Discount } from "./discount.model"
import { Product } from "./product.model"

export interface Basket{
    totalValue:number
    subtotalValue:number
    discountsValue:number
    productDiscounts:BasketProductDiscount []
}

export interface BasketProductDiscount{
    product: Product
    discount: Discount
    ProductQuantity:number
}